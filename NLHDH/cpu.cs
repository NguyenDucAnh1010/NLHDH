using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NLHDH
{
    public partial class cpu : Form
    {
        public cpu()
        {
            InitializeComponent();
        }

        private void cpu_Load(object sender, EventArgs e)
        {
            // Tắt đường viền của các nút
            button4.FlatAppearance.BorderSize = 0;
            button5.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.BorderSize = 0;
        }

        // chuyển sang form fcfs
        private void button1_Click(object sender, EventArgs e)
        {
            // Ẩn form hiện tại
            Hide();

            // Tạo một đối tượng "fcfs" từ lớp (class) "fcfs"
            fcfs form = new fcfs();

            // Hiển thị form "fcfs" dưới dạng hộp thoại
            form.ShowDialog();

            // Đặt kết quả trả về của hộp thoại là "DialogResult.OK"
            DialogResult = DialogResult.OK;

            // Đóng form hiện tại
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // chuyển sang form rr
        private void button3_Click(object sender, EventArgs e)
        {
            // Ẩn form hiện tại
            Hide();

            // Tạo một đối tượng "rr" từ lớp (class) "rr"
            rr form = new rr();

            // Hiển thị form "rr" dưới dạng hộp thoại
            form.ShowDialog();

            // Đặt kết quả trả về của hộp thoại là "DialogResult.OK"
            DialogResult = DialogResult.OK;

            // Đóng form hiện tại
            Close();
        }

        // chuyển sang form sjf
        private void button4_Click(object sender, EventArgs e)
        {
            // Ẩn form hiện tại
            Hide();

            // Tạo một đối tượng "sjf" từ lớp (class) "sjf"
            sjf form = new sjf();

            // Hiển thị form "sjf" dưới dạng hộp thoại
            form.ShowDialog();

            // Đặt kết quả trả về của hộp thoại là "DialogResult.OK"
            DialogResult = DialogResult.OK;

            // Đóng form hiện tại
            Close();
        }

        // chuyển sang form srtn
        private void button5_Click(object sender, EventArgs e)
        {
            // Ẩn form hiện tại
            Hide();

            // Tạo một đối tượng "srtn" từ lớp (class) "srtn"
            srtn form = new srtn();

            // Hiển thị form "srtn" dưới dạng hộp thoại
            form.ShowDialog();

            // Đặt kết quả trả về của hộp thoại là "DialogResult.OK"
            DialogResult = DialogResult.OK;

            // Đóng form hiện tại
            Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Ẩn form hiện tại
            Hide();

            // Tạo một đối tượng "TackClone" từ lớp (class) "srtn"
            taskclone form = new taskclone();

            // Hiển thị form "srtn" dưới dạng hộp thoại
            form.ShowDialog();

            // Đặt kết quả trả về của hộp thoại là "DialogResult.OK"
            DialogResult = DialogResult.OK;

            // Đóng form hiện tại
            Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Ẩn form hiện tại
            Hide();

            // Tạo một đối tượng "TackClone" từ lớp (class) "srtn"
            ShareData form = new ShareData();

            // Hiển thị form "srtn" dưới dạng hộp thoại
            form.ShowDialog();

            // Đặt kết quả trả về của hộp thoại là "DialogResult.OK"
            DialogResult = DialogResult.OK;

            // Đóng form hiện tại
            Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
