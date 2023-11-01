using System.Diagnostics;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.Xml.Linq;

namespace NLHDH
{
    public partial class taskclone : Form
    {
        Process[] process;
        public taskclone()
        {
            InitializeComponent();

            // Tắt đường viền của các nút
            button2.FlatAppearance.BorderSize = 0;
        }

        void GetProcess()
        {
            process = Process.GetProcesses();
            foreach (var item in process)
            {
                ListViewItem process = new ListViewItem() { Text = item.ProcessName };
                process.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = item.Id.ToString() });
                process.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = item.WorkingSet64.ToString() });
                lv_process.Items.Add(process);
            }
        }

        private void Group3_Task_Load(object sender, EventArgs e)
        {
            GetProcess();
        }

        private void Reload()
        {
            lv_process.Items.Clear();
            GetProcess();
        }

        private void btn_kill_Click(object sender, EventArgs e)
        {
            if (lv_process.SelectedItems.Count > 0)
            {
                foreach (var item in process)
                {
                    if (item.ProcessName == lv_process.SelectedItems[0].Text)
                    {
                        DialogResult result = MessageBox.Show($"Bạn thực sự muốn đóng tiến trình {lv_process.SelectedItems[0].Text}", "", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            item.Kill();
                            MessageBox.Show("Đóng thành công tiến trình!", "", MessageBoxButtons.OK);
                            Reload();
                            return;
                        }
                    }
                }

            }
        }

        private void btn_reload_Click(object sender, EventArgs e)
        {
            Reload();
        }

        private void lv_process_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Ẩn form hiện tại
            Hide();

            // Tạo một đối tượng "TackClone" từ lớp (class) "srtn"
            cpu form = new cpu();

            // Hiển thị form "srtn" dưới dạng hộp thoại
            form.ShowDialog();

            // Đặt kết quả trả về của hộp thoại là "DialogResult.OK"
            DialogResult = DialogResult.OK;

            // Đóng form hiện tại
            Close();
        }
    }
}