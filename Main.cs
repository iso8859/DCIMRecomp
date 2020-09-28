using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace DCIMRecomp
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            m_addVersion = AddVersionImp;
            txtSrc.Text = Properties.Settings.Default.Src;
            btnSubDir.Checked = Properties.Settings.Default.SubDir;
            txtDest.Text = Properties.Settings.Default.Dest;
            bntImages.Checked = Properties.Settings.Default.ImageConversion;
            btnBigImages.Checked = Properties.Settings.Default.More200k;
            trackBar1.Value = Properties.Settings.Default.JPEGQuality;
            lblCompressionLevel.Text = trackBar1.Value.ToString();
            btnMovies.Checked = Properties.Settings.Default.ConvertMov;
            btnShowAdvancedOptions.Checked = Properties.Settings.Default.ShowAdvanced;
            txtName.Text = Properties.Settings.Default.Name;
            btnRemoveOriginals.Checked = Properties.Settings.Default.EraseSource;
            btnShowAdvancedOptions_CheckedChanged(null, null);
            comboBox1.SelectedIndex = Properties.Settings.Default.VideoCodec;
            btnReorganise.Checked = Properties.Settings.Default.YYYYMM;

            if (string.IsNullOrEmpty(txtDest.Text))
                txtDest.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            // System.Net.Dns.BeginGetHostAddresses("dcimrecompversion.m4f.eu", CheckVersion, null);
        }

        delegate void AddVersion();
        AddVersion m_addVersion;

        void AddVersionImp()
        {
            Text += " - dernière version";
        }

        void CheckVersion(IAsyncResult result)
        {
            int currentVersion = 1 * 256 + 0;
            try
            {
                System.Net.IPAddress[] availVersion = System.Net.Dns.EndGetHostAddresses(result);
                if (availVersion.Length == 1)
                {
                    string[] items = availVersion[0].ToString().Split('.');
                    if (items.Length == 4)
                    {
                        // version.url2jpeg.com  v1.v2.f1.f2
                        // v1 et v2 = version majeur, mineur
                        // f1*256+f2 = build obligatoire pour fonctionner
                        int available = Convert.ToInt32(items[0])*256+Convert.ToInt32(items[1]);
                        if (available > currentVersion)
                        {
                            if (MessageBox.Show("La version " + availVersion[0].ToString() + " est disponible.\r\nVoulez-vous aller sur le site web de DCIMRecomp ?", "Mise à jour", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                process2.Start();
                        }
                        else
                            Invoke(m_addVersion);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            lblCompressionLevel.Text = trackBar1.Value.ToString();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Enabled = bntImages.Checked;
        }

        private void btnSrc_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = txtSrc.Text;
            folderBrowserDialog1.ShowNewFolderButton = false;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                txtSrc.Text = folderBrowserDialog1.SelectedPath;
        }

        private void btnDest_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = txtDest.Text;
            folderBrowserDialog1.ShowNewFolderButton = true;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                txtDest.Text = folderBrowserDialog1.SelectedPath;
        }

        List<string> srcImages;
        List<string> srcMovies;
        List<string> processed;
        long finalSize;
        string destFormatMovie;

        private long GetFileSize(string file)
        {
            FileInfo fi = new FileInfo(file);
            return fi.Length;
        }

        private void btnSaveParams_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Src = txtSrc.Text;
            Properties.Settings.Default.SubDir = btnSubDir.Checked;
            Properties.Settings.Default.Dest = txtDest.Text;
            Properties.Settings.Default.ImageConversion = bntImages.Checked;
            Properties.Settings.Default.More200k = btnBigImages.Checked;
            Properties.Settings.Default.JPEGQuality = trackBar1.Value;
            Properties.Settings.Default.ConvertMov = btnMovies.Checked;
            Properties.Settings.Default.ShowAdvanced = btnShowAdvancedOptions.Checked;
            Properties.Settings.Default.Name = txtName.Text;
            Properties.Settings.Default.EraseSource = btnRemoveOriginals.Checked;
            Properties.Settings.Default.VideoCodec = comboBox1.SelectedIndex;
            Properties.Settings.Default.YYYYMM = btnReorganise.Checked;
            Properties.Settings.Default.Save();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSrc.Text)) // Trouver premier disque removable
            {
                SortedDictionary<long, DriveInfo> sortedDrives = new SortedDictionary<long, DriveInfo>();
                DriveInfo[] drives = DriveInfo.GetDrives();
                foreach (DriveInfo drive in drives)
                {
                    if (drive.DriveType == DriveType.Removable)
                    {
                        try
                        {
                            // Essayer de récupérer la taille, si disque vide => exception
                            sortedDrives.Add(drive.TotalSize, drive);
                        }
                        catch
                        {
                        }
                    }
                }
                foreach (long l in sortedDrives.Keys)
                {
                    DriveInfo drive = sortedDrives[l];
                    if (System.IO.Directory.Exists(drive.Name + "DCIM"))
                        txtSrc.Text = drive.Name + "DCIM";
                    else
                        txtSrc.Text = drive.Name;
                    btnSubDir.Checked = true;
                    break;
                }
            }

            btnSaveParams_Click(null, null);

            srcImages = new List<string>();
            srcMovies = new List<string>();

            if (!string.IsNullOrEmpty(txtSrc.Text) && !string.IsNullOrEmpty(txtDest.Text))
            {
                lblFinished.Visible = false;
                string[] tmp = System.IO.Directory.GetFiles(Properties.Settings.Default.Src, "*.*", btnSubDir.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
                long totalSize = 0;

                foreach (string file in tmp)
                {
                    string ext = System.IO.Path.GetExtension(file).ToUpper();
                    string ext2 = System.IO.Path.GetExtension(System.IO.Path.GetFileNameWithoutExtension(file)).ToUpper();
                    if (ext2 != "RC")
                    {
                        if (bntImages.Checked && (ext == ".JPG" || ext == ".JPEG" || ext == ".TIFF" || ext == ".TIF" || ext == ".PNG" || ext == ".BMP"))
                        {
                            long size = GetFileSize(file);
                            if (!btnBigImages.Checked || size > 200 * 1024)
                            {
                                srcImages.Add(file);
                                totalSize += size;
                            }
                        }
                        if (btnMovies.Checked && (ext == ".MOV" || ext == ".AVI" || ext == ".MPG" || ext == ".WMV" || ext == ".MP4" || ext == ".3GP" || ext == ".MTS"))
                        {
                            long size = GetFileSize(file);
                            srcMovies.Add(file);
                            totalSize += size;
                        }
                    }
                }

                progressBar1.Maximum = srcImages.Count + srcMovies.Count;
                lblSizeBefore.Text = string.Format(lblSizeBefore.Tag.ToString(), totalSize / (1024 * 1024));
                lblSizeAfter.Text = string.Format(lblSizeAfter.Tag.ToString(), 0);

                btnStop.Enabled = true;
                btnStart.Enabled = false;

                processed = new List<string>();
                finalSize = 0;
                destFormatMovie = comboBox1.SelectedItem.ToString();

                backgroundWorker1.RunWorkerAsync();
                //backgroundWorker1_DoWork(null, null);
            }
            else
                MessageBox.Show("Il faut définir source et destination", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        static public ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                    return codec;
            }
            return null;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            System.Threading.Thread.CurrentThread.Priority = System.Threading.ThreadPriority.BelowNormal;

            try
            {
                ImageCodecInfo jpegEncoder = GetEncoder(ImageFormat.Jpeg);
                string name = string.Format(Properties.Settings.Default.Name, DateTime.Now);

                foreach (string image in srcImages)
                {
                    // Trouver le chemin exact
                    string path = System.IO.Path.GetDirectoryName(image);
                    string deltaPath = path.Substring(Properties.Settings.Default.Src.Length);
                    FileInfo fiSrc = new FileInfo(image);

                    string finalName = System.IO.Path.GetFileNameWithoutExtension(image) + ".rc" + System.IO.Path.GetExtension(image);
                    string dest = Properties.Settings.Default.Dest + "\\" + name + "\\" + deltaPath + "\\" + finalName;
                    DateTime date = fiSrc.LastWriteTime;
                    try
                    {
                        using (ExifLib.ExifReader reader = new ExifLib.ExifReader(image))
                        {
                            DateTime date2;
                            reader.GetTagValue<DateTime>(ExifLib.ExifTags.DateTimeDigitized, out date2);
                            if (date2 != DateTime.MinValue)
                                date = date2;
                        }
                    }
                    catch { }
                    if (btnReorganise.Checked)
                        dest = Properties.Settings.Default.Dest + string.Format("\\{0:0000}{1:00}\\{2}", date.Year, date.Month, finalName);
                    uData.CDInterface.CreateDirectoryForFile(dest);
                    bool bRecompress = true;
                    if (System.IO.File.Exists(dest))
                        bRecompress = false;

                    if (bRecompress)
                    {
                        try
                        {
                            Image bmp = Bitmap.FromFile(image);
                            List<PropertyItem> items = new List<PropertyItem>(bmp.PropertyItems);
                            Bitmap tmp = new Bitmap(bmp);
                            foreach (PropertyItem item in items)
                                tmp.SetPropertyItem(item);

                            System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                            EncoderParameters myEncoderParameters = new EncoderParameters(1);
                            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, Convert.ToInt64(Properties.Settings.Default.JPEGQuality));
                            myEncoderParameters.Param[0] = myEncoderParameter;

                            try
                            {
                                tmp.Save(dest, jpegEncoder, myEncoderParameters);
                            }
                            catch
                            {
                            }
                            finally
                            {
                                if (!System.IO.File.Exists(dest))
                                    System.IO.File.Copy(image, dest);
                            }
                            tmp.Dispose();
                            bmp.Dispose();
                            FileInfo fiDest = new FileInfo(dest);
                            fiDest.CreationTime = date;
                            fiDest.LastAccessTime = date;
                            fiDest.LastWriteTime = date;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(string.Format("Erreur {0}\r\nsur l'image {1}", ex.Message, image));
                            bRecompress = false;
                        }
                    }
                    if (bRecompress)
                    {
                        finalSize += GetFileSize(dest);
                        processed.Add(image);
                    }
                    backgroundWorker1.ReportProgress(0);
                    if (backgroundWorker1.CancellationPending)
                    {
                        e.Cancel = true;
                        break;
                    }
                }

                if (!e.Cancel)
                {
                    foreach (string movie in srcMovies)
                    {
                        FileInfo fiSrc = new FileInfo(movie);
                        // Trouver le chemin exact
                        string path = System.IO.Path.GetDirectoryName(movie);
                        string deltaPath = path.Substring(Properties.Settings.Default.Src.Length);

                        string finalName = System.IO.Path.GetFileNameWithoutExtension(movie) + ".rc" + destFormatMovie;
                        string dest = Properties.Settings.Default.Dest + "\\" + name + "\\" + deltaPath + "\\" + finalName;
                        if (btnReorganise.Checked)
                            dest = Properties.Settings.Default.Dest + string.Format("\\{0:0000}{1:00}\\{2}", fiSrc.LastWriteTime.Year, fiSrc.LastWriteTime.Month, finalName);
                        uData.CDInterface.CreateDirectoryForFile(dest);
                        if (!System.IO.File.Exists(dest))
                        {
                            System.Diagnostics.Process process = new System.Diagnostics.Process();
                            process.StartInfo.FileName = AppDomain.CurrentDomain.BaseDirectory + "ffmpeg.exe";
                            process.StartInfo.Arguments = string.Format("-vsync 2 -y -i \"{0}\" \"{1}\"", movie, dest);
                            process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Minimized;
                            process.Start();
                            process.WaitForExit();

                            if (System.IO.File.Exists(dest))
                            {
                                FileInfo fiDest = new FileInfo(dest);
                                fiDest.CreationTimeUtc = fiSrc.CreationTimeUtc;
                                fiDest.LastAccessTimeUtc = fiSrc.LastAccessTimeUtc;
                                fiDest.LastWriteTimeUtc = fiSrc.LastWriteTimeUtc;
                            }
                            else
                                System.IO.File.Copy(movie, dest);
                        }
                        finalSize += GetFileSize(dest);
                        processed.Add(movie);
                        backgroundWorker1.ReportProgress(0);
                        if (backgroundWorker1.CancellationPending)
                        {
                            e.Cancel = true;
                            break;
                        }
                    }
                }

                if (!e.Cancel)
                {
                    System.Diagnostics.Process.Start("explorer.exe", Properties.Settings.Default.Dest + "\\" + name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (!e.Cancel)
                {
                    if (Properties.Settings.Default.EraseSource)
                    {
                        foreach (string image in srcImages)
                            System.IO.File.Delete(image);
                        foreach (string movie in srcMovies)
                            System.IO.File.Delete(movie);
                    }
                }
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = processed.Count;
            lblSizeAfter.Text = string.Format(lblSizeAfter.Tag.ToString(), finalSize / (1024 * 1024));
            Text = string.Format("{0}/{1}", processed.Count, srcImages.Count + srcMovies.Count);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnStop.Enabled = false;
            btnStart.Enabled = true;
            progressBar1.Value = 0;
            txtSrc_TextChanged(null, null);
            txtDest_TextChanged(null, null);
            lblFinished.Visible = true;
        }

        private void btnWebSite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            process2.Start();
        }

        private void btnShowAdvancedOptions_CheckedChanged(object sender, EventArgs e)
        {
            Size = new Size(Size.Width, btnShowAdvancedOptions.Checked ? 561 : 234);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            process1.Start();
        }

        private void txtSrc_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSrc.Text))
            {
                try
                {
                    DriveInfo di = new DriveInfo(txtSrc.Text.Substring(0, 1));
                    lblSrcSpace.Text = string.Format("{0:###.##}%", Convert.ToDouble(di.AvailableFreeSpace) / Convert.ToDouble(di.TotalSize) * 100.0);
                }
                catch { }
            }
        }

        private void txtDest_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDest.Text))
            {
                try
                {
                    DriveInfo di = new DriveInfo(txtDest.Text.Substring(0, 1));
                    lblDestSpace.Text = string.Format("{0:###.##}%", Convert.ToDouble(di.AvailableFreeSpace) / Convert.ToDouble(di.TotalSize) * 100.0);
                }
                catch { }
            }
        }
    }
}
