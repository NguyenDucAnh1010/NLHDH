using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.IO;
using System.IO.Pipes;
using System.Net.Http;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;

namespace NLHDH
{
    public partial class ShareData : Form
    {
        private SemaphoreSlim semaphore;
        private string fileContent;
        private string translateLanguage = "en";
        private Thread readThread;
        private Thread translateThread;
        private bool isRunning = false;
        private FileStream fileStream;
        private string filePath;
        public ShareData()
        {
            InitializeComponent();
            semaphore = new SemaphoreSlim(1, 1);
            fileContent = string.Empty;
        }

        private void ShareData_Load(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                try
                {
                    filePath = openFileDialog1.FileName;
                    fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                    // Read the file content into the fileContent variable
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }

                    // Create a new thread to read the file content and assign it to richTextBox1
                    readThread = new Thread(() => ReadFileAndSetText(fileContent, richTextBox1));
                    readThread.IsBackground = true; // Đánh dấu luồng là luồng nền
                    readThread.Start();

                    // Create a new thread for translation
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileContent == "" & richTextBox1.Text != "")
            {
                DialogResult result = MessageBox.Show("Bạn có muốn tạo file không?", "Lưu lại file", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = saveFileDialog.FileName;
                        File.WriteAllText(filePath, richTextBox1.Text);
                        fileContent = richTextBox1.Text;
                    }
                }
            }
            else
            {
                if (richTextBox1.Text != fileContent)
                {
                    DialogResult result = MessageBox.Show("Bạn có muốn lưu lại file không?", "Lưu lại file", MessageBoxButtons.YesNoCancel);
                    if (result == DialogResult.Yes)
                    {
                        File.WriteAllText(filePath, richTextBox1.Text);
                        fileContent = richTextBox1.Text;
                    }
                }
            }
        }
        private void TranslateTextThread(RichTextBox richTextBox1, RichTextBox richTextBox2)
        {
            while (isRunning == true)
            {
                string content = string.Empty;

                // Wait for the semaphore to be released
                semaphore.Wait();

                try
                {
                    // Get the content from richTextBox1
                    content = GetRichTextBoxText(richTextBox1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    // Release the semaphore
                    semaphore.Release();
                }

                // Translate the content to English
                string translatedText = "";
                if (translateLanguage == "en")
                {
                    translatedText = TranslateToEnglish(content);
                }
                else
                {
                    translatedText = TranslateToVietNam(content);
                }
                // Set the translated content to richTextBox2
                SetRichTextBoxText(richTextBox2, translatedText);

                // Sleep for a short duration to avoid excessive CPU usage
                isRunning = false;
            }
        }

        private string GetRichTextBoxText(RichTextBox richTextBox)
        {
            string text = string.Empty;

            if (richTextBox.InvokeRequired)
            {
                richTextBox.Invoke(new MethodInvoker(delegate
                {
                    text = richTextBox.Text;
                }));
            }
            else
            {
                text = richTextBox.Text;
            }

            return text;
        }

        private void SetRichTextBoxText(RichTextBox richTextBox, string text)
        {
            if (richTextBox.InvokeRequired)
            {
                richTextBox.Invoke(new MethodInvoker(delegate
                {
                    richTextBox.Text = text;
                }));
            }
            else
            {
                richTextBox.Text = text;
            }
        }

        private void ReadFileAndSetText(string content, RichTextBox richTextBox)
        {
            semaphore.Wait();

            try
            {
                // Set the content to richTextBox
                SetRichTextBoxText(richTextBox, content);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                semaphore.Release();
            }
        }
        private string TranslateToEnglish(string text)
        {
            string translation = string.Empty;

            try
            {
                string encode = Uri.EscapeUriString(text);
                string url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl=vi&tl=en&dt=t&q={encode}";

                HttpClient httpClient = new HttpClient();
                string result = httpClient.GetStringAsync(url).GetAwaiter().GetResult();
                // Parse the translation result
                //result = result.Substring(4); // Remove the initial array bracket
                //int endIndex = result.IndexOf('"');
                //translation = result.Substring(0, endIndex).Trim();
                JArray jsonArray = JArray.Parse(result);
                foreach (JToken token in jsonArray)
                {
                    int tokenCount = token.Count();
                    for (int i = 0; i < tokenCount; i++)
                    {
                        string textEnglish = token[i][0].ToString();
                        translation += textEnglish;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while translating: " + ex.Message);
            }

            return translation;

        }
        public string TranslateToVietNam(string text)
        {
            string translation = string.Empty;

            try
            {
                string encode = Uri.EscapeUriString(text);
                string url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl=en&tl=vi&dt=t&q={encode}";

                HttpClient httpClient = new HttpClient();
                string result = httpClient.GetStringAsync(url).GetAwaiter().GetResult();
                // Parse the translation result
                //result = result.Substring(4); // Remove the initial array bracket
                //int endIndex = result.IndexOf('"');
                //translation = result.Substring(0, endIndex).Trim();
                JArray jsonArray = JArray.Parse(result);
                foreach (JToken token in jsonArray)
                {
                    int tokenCount = token.Count();
                    for (int i = 0; i < tokenCount; i++)
                    {
                        string textEnglish = token[i][0].ToString();
                        translation += textEnglish;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while translating: " + ex.Message);
            }

            return translation;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Create a new thread to read the file content and assign it to 

                // Create a new thread for translation
                isRunning = true;
                translateThread = new Thread(() => TranslateTextThread(richTextBox1, richTextBox2));
                translateThread.IsBackground = true; // Đánh dấu luồng là luồng nền
                translateThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ShareData_Load_1(object sender, EventArgs e)
        {

        }

        private void ShareData_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string temp = richTextBox1.Text;
            richTextBox1.Text = richTextBox2.Text;
            richTextBox2.Text = temp;
            if (translateLanguage == "vi")
            {
                translateLanguage = "en";
                pictureBox2.Image = Properties.Resources.vie;
                pictureBox3.Image = Properties.Resources.eng__2_;
            }
            else
            {
                translateLanguage = "vi";
                pictureBox2.Image = Properties.Resources.eng__2_;
                pictureBox3.Image = Properties.Resources.vie; ;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }



        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (richTextBox1.Text != fileContent)
            {
                DialogResult result = MessageBox.Show("Bạn có muốn lưu lại file không?", "Lưu lại file", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    File.WriteAllText(filePath, richTextBox1.Text);
                    fileContent = richTextBox1.Text;
                }
            }
            if (fileStream != null)
            {
                fileStream.Close();
                fileStream.Dispose();
                fileStream = null;
                richTextBox1.Text = "";
                richTextBox2.Text = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hide(); // Ẩn form hiện tại

            // Tạo một thể hiện mới của lớp fcfs
            cpu form = new cpu();

            // Hiển thị form mới (fcfs) dưới dạng hộp thoại chờ và ngăn chặn người dùng tương tác với form gốc cho đến khi form fcfs được đóng
            form.ShowDialog();

            // Đặt kết quả của hộp thoại thành DialogResult.OK. Điều này cho biết rằng hộp thoại đã được đóng một cách thành công và trạng thái trả về là OK.
            DialogResult = DialogResult.OK;

            Close(); // Đóng form hiện tại
        }
    }
}