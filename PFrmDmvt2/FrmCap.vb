Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms
Imports AForge.Video
Imports AForge.Video.DirectShow

Public Class FrmCap
    Private m_FilePath As String
    Private videoDevices As FilterInfoCollection
    Private videoSource As VideoCaptureDevice
    Private isClosing As Boolean = False
    Private Delegate Sub UpdatePreviewDelegate(ByVal bmp As Bitmap)

    Public Sub New(ByVal filePath As String)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        m_FilePath = filePath
    End Sub

    Private Sub FrmCap_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            isClosing = False
            videoDevices = New FilterInfoCollection(FilterCategory.VideoInputDevice)

            If videoDevices.Count = 0 Then
                MessageBox.Show("Không tìm thấy thiết bị Camera/Webcam nào kết nối với máy tính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.Close()
                Return
            End If

            ' Populate combobox with devices
            cbDevices.Items.Clear()
            For Each device As FilterInfo In videoDevices
                cbDevices.Items.Add(device.Name)
            Next

            ' Add handlers for ComboBox changes
            AddHandler cbDevices.SelectedIndexChanged, AddressOf cbDevices_SelectedIndexChanged
            AddHandler cbResolutions.SelectedIndexChanged, AddressOf cbResolutions_SelectedIndexChanged

            ' Select first device by default
            cbDevices.SelectedIndex = 0
        Catch ex As Exception
            MessageBox.Show("Lỗi khi khởi tạo camera: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cbDevices_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            ' Stop current camera if running
            StopCamera()

            Dim deviceIndex As Integer = cbDevices.SelectedIndex
            If deviceIndex < 0 OrElse deviceIndex >= videoDevices.Count Then Return

            Dim deviceMoniker As String = videoDevices(deviceIndex).MonikerString
            videoSource = New VideoCaptureDevice(deviceMoniker)

            ' Populate resolutions for this device
            cbResolutions.Items.Clear()
            If videoSource.VideoCapabilities IsNot Nothing AndAlso videoSource.VideoCapabilities.Length > 0 Then
                Dim maxResolutionIndex As Integer = 0
                Dim maxArea As Integer = 0
                For i As Integer = 0 To videoSource.VideoCapabilities.Length - 1
                    Dim cap As VideoCapabilities = videoSource.VideoCapabilities(i)
                    cbResolutions.Items.Add(String.Format("{0} x {1} ({2} fps)", cap.FrameSize.Width, cap.FrameSize.Height, cap.AverageFrameRate))
                    
                    Dim area As Integer = cap.FrameSize.Width * cap.FrameSize.Height
                    If area > maxArea Then
                        maxArea = area
                        maxResolutionIndex = i
                    End If
                Next
                ' Select the highest resolution possible
                cbResolutions.SelectedIndex = maxResolutionIndex
            Else
                cbResolutions.Items.Add("Mặc định (Default)")
                cbResolutions.SelectedIndex = 0
            End If
        Catch ex As Exception
            MessageBox.Show("Lỗi khi chọn thiết bị camera: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cbResolutions_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            If videoSource IsNot Nothing Then
                ' Stop capture before changing resolution
                Dim wasRunning As Boolean = videoSource.IsRunning
                If wasRunning Then
                    StopCamera()
                    ' Recreate videoSource since we stopped it
                    Dim deviceIndex As Integer = cbDevices.SelectedIndex
                    videoSource = New VideoCaptureDevice(videoDevices(deviceIndex).MonikerString)
                End If

                If videoSource.VideoCapabilities IsNot Nothing AndAlso videoSource.VideoCapabilities.Length > 0 Then
                    Dim resIndex As Integer = cbResolutions.SelectedIndex
                    If resIndex >= 0 AndAlso resIndex < videoSource.VideoCapabilities.Length Then
                        videoSource.VideoResolution = videoSource.VideoCapabilities(resIndex)
                    End If
                End If

                AddHandler videoSource.NewFrame, AddressOf videoSource_NewFrame
                videoSource.Start()
            End If
        Catch ex As Exception
            MessageBox.Show("Lỗi khi thay đổi độ phân giải camera: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub videoSource_NewFrame(sender As Object, eventArgs As NewFrameEventArgs)
        If isClosing Then Return
        Try
            Dim bmp As Bitmap = DirectCast(eventArgs.Frame.Clone(), Bitmap)
            If Me.InvokeRequired Then
                Me.BeginInvoke(New UpdatePreviewDelegate(AddressOf UpdatePreview), New Object() {bmp})
            Else
                UpdatePreview(bmp)
            End If
        Catch ex As Exception
            ' Ignore error on close
        End Try
    End Sub

    Private Sub UpdatePreview(bmp As Bitmap)
        If isClosing Then
            bmp.Dispose()
            Return
        End If
        Try
            Dim oldImg As Image = pbPreview.Image
            pbPreview.Image = bmp
            If oldImg IsNot Nothing Then
                oldImg.Dispose()
            End If
        Catch ex As Exception
            bmp.Dispose()
        End Try
    End Sub

    Private Sub btnCapture_Click(sender As Object, e As EventArgs) Handles btnCapture.Click
        Try
            If pbPreview.Image Is Nothing Then
                MessageBox.Show("Không có hình ảnh từ camera để chụp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Copy the current image safely
            Dim capImg As Bitmap = Nothing
            SyncLock pbPreview
                If pbPreview.Image IsNot Nothing Then
                    capImg = DirectCast(pbPreview.Image.Clone(), Bitmap)
                End If
            End SyncLock

            If capImg IsNot Nothing Then
                ' Stop camera first to free resource
                StopCamera()

                ' Ensure directory exists
                Dim dir As String = Path.GetDirectoryName(m_FilePath)
                If Not String.IsNullOrEmpty(dir) AndAlso Not Directory.Exists(dir) Then
                    Directory.CreateDirectory(dir)
                End If

                ' Save the image to the specified file path
                ' Check if file already exists, delete it first to overwrite safely
                If File.Exists(m_FilePath) Then
                    File.Delete(m_FilePath)
                End If
                capImg.Save(m_FilePath, System.Drawing.Imaging.ImageFormat.Jpeg)
                capImg.Dispose()

                Me.DialogResult = DialogResult.OK
                Me.Close()
            Else
                MessageBox.Show("Không thể chụp được ảnh, vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Lỗi khi lưu ảnh: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FrmCap_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        isClosing = True
        StopCamera()
    End Sub

    Private Sub StopCamera()
        Try
            If videoSource IsNot Nothing Then
                RemoveHandler videoSource.NewFrame, AddressOf videoSource_NewFrame
                If videoSource.IsRunning Then
                    videoSource.SignalToStop()
                End If
                videoSource = Nothing
            End If
            System.Threading.Thread.Sleep(100) ' Give a short delay for thread exit
            If pbPreview.Image IsNot Nothing Then
                Dim oldImg As Image = pbPreview.Image
                pbPreview.Image = Nothing
                oldImg.Dispose()
            End If
        Catch ex As Exception
            ' Ignore error on stop
        End Try
    End Sub
End Class
