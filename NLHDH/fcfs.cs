using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.Xml.Linq;

namespace NLHDH
{
    public partial class fcfs : Form
    {
        public fcfs()
        {
            InitializeComponent();

            // Xác định kiểu dữ liệu của cột là số
            dataGridView1.Columns["Column2"].ValueType = typeof(int);
            dataGridView1.Columns["Column3"].ValueType = typeof(int);

            // Tắt đường viền của các nút
            button2.FlatAppearance.BorderSize = 0;
        }

        // hàm chuyển đổi dữ liệu DataGridView sang DataTable
        public DataTable LayDuLieuTuDataGridView()
        {
            // Sắp xếp dữ liệu trong DataGridView theo cột "Column1"
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n - (i + 1); j++)
                {
                    // So sánh giá trị của hai dòng liên tiếp trong cột "Column1"
                    if (Convert.ToInt32(dataGridView1.Rows[j].Cells["Column1"].Value)
                        > Convert.ToInt32(dataGridView1.Rows[j + 1].Cells["Column1"].Value))
                    {
                        // Hoán đổi vị trí hai dòng trong DataGridView
                        DataGridViewRow row1 = dataGridView1.Rows[j];
                        DataGridViewRow row2 = dataGridView1.Rows[j + 1];
                        dataGridView1.Rows.RemoveAt(j); // Xóa dòng thứ j
                        dataGridView1.Rows.RemoveAt(j); // Xóa dòng thứ j+1 (sau khi xóa dòng j, dòng j+1 trở thành dòng j)
                        dataGridView1.Rows.Insert(j, row1); // Chèn dòng row1 vào vị trí thứ j
                        dataGridView1.Rows.Insert(j, row2); // Chèn dòng row2 vào vị trí thứ j
                    }
                }
            }

            DataTable dataTable = new DataTable();

            // Tạo cột cho DataTable
            for (int i = 0; i < 3; i++)
            {
                dataTable.Columns.Add("Column" + (i + 1).ToString());
            }

            // Lấy dữ liệu từ DataGridView và thêm vào DataTable
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataRow dataRow = dataTable.NewRow();
                for (int i = 0; i < 3; i++)
                {
                    dataRow[i] = row.Cells[i].Value;
                }
                dataTable.Rows.Add(dataRow);
            }

            return dataTable;
        }

        // biến lưu lại số lượng projects
        decimal n = 0;

        // hàm nhận dữ liệu từ form khác chuyển tới
        public void NhanDuLieuTuFormGoc(DataTable duLieu)
        {
            // Sử dụng dữ liệu nhận được từ Form gốc ở đây
            n = duLieu.Rows.Count; // Lấy số lượng dòng trong DataTable nhận được và gán cho biến n
            numericUpDown1.Value = n; // Thiết lập giá trị của numericUpDown1 bằng n

            dataGridView1.Rows.Clear(); // Xóa tất cả các dòng hiện tại trong dataGridView1

            for (int i = 0; i < n; i++)
            {
                // Thêm một hàng mới vào bảng
                dataGridView1.Rows.Add();

                // Thiết lập giá trị cho từng ô trong hàng

                // Giả sử cột "PID" đã được tạo trước đó, gán giá trị của cột "PID" tương ứng trong DataTable vào ô tương ứng trong dataGridView1
                dataGridView1.Rows[i].Cells["Column1"].Value = duLieu.Rows[i][0];

                // Giả sử cột "ArrivalTime" đã được tạo trước đó, gán giá trị của cột "ArrivalTime" tương ứng trong DataTable vào ô tương ứng trong dataGridView1
                dataGridView1.Rows[i].Cells["Column2"].Value = duLieu.Rows[i][1];

                // Giả sử cột "BurstTime" đã được tạo trước đó, gán giá trị của cột "BurstTime" tương ứng trong DataTable vào ô tương ứng trong dataGridView1
                dataGridView1.Rows[i].Cells["Column3"].Value = duLieu.Rows[i][2];

                // Giả sử cột "Complete" đã được tạo trước đó, gán giá trị 0 vào ô tương ứng trong dataGridView1
                dataGridView1.Rows[i].Cells["Column4"].Value = 0;

                // Giả sử cột "Turnaround" đã được tạo trước đó, gán giá trị 0 vào ô tương ứng trong dataGridView1
                dataGridView1.Rows[i].Cells["Column5"].Value = 0;

                // Giả sử cột "Waiting" đã được tạo trước đó, gán giá trị 0 vào ô tương ứng trong dataGridView1
                dataGridView1.Rows[i].Cells["Column6"].Value = 0;
            }
        }

        // Hàm thực hiện thuật toán fcfs
        private void button3_Click(object sender, EventArgs e)
        {
            decimal avgwt1 = 0; // Khởi tạo biến avgwt1 để tính trung bình của wt (waiting time)
            decimal avgta1 = 0; // Khởi tạo biến avgta1 để tính trung bình của ta (turnaround time)

            // Sắp xếp các dòng trong dataGridView1 theo cột "ArrivalTime" (Column2) theo thứ tự tăng dần
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n - (i + 1); j++)
                {
                    if (Convert.ToInt32(dataGridView1.Rows[j].Cells["Column2"].Value)
                        > Convert.ToInt32(dataGridView1.Rows[j + 1].Cells["Column2"].Value))
                    {
                        // Hoán đổi hai dòng trong dataGridView1
                        DataGridViewRow row1 = dataGridView1.Rows[j];
                        DataGridViewRow row2 = dataGridView1.Rows[j + 1];
                        dataGridView1.Rows.RemoveAt(j);
                        dataGridView1.Rows.RemoveAt(j);
                        dataGridView1.Rows.Insert(j, row1);
                        dataGridView1.Rows.Insert(j, row2);
                    }
                }
            }

            // Tính toán các giá trị cột "Complete" (Column4), "Turnaround" (Column5) và "Waiting" (Column6) trong dataGridView1
            for (int i = 0; i < n; i++)
            {
                if (i == 0)
                {
                    // Nếu là dòng đầu tiên, gán giá trị của cột "ArrivalTime" (Column2) + cột "BurstTime" (Column3) vào cột "Complete" (Column4)
                    dataGridView1.Rows[i].Cells["Column4"].Value =
                        Convert.ToInt32(dataGridView1.Rows[i].Cells["Column2"].Value)
                        + Convert.ToInt32(dataGridView1.Rows[i].Cells["Column3"].Value);
                }
                else
                {
                    if (Convert.ToInt32(dataGridView1.Rows[i].Cells["Column2"].Value)
                        > Convert.ToInt32(dataGridView1.Rows[i - 1].Cells["Column4"].Value))
                    {
                        // Nếu cột "ArrivalTime" (Column2) của dòng hiện tại lớn hơn cột "Complete" (Column4) của dòng trước đó,
                        // gán giá trị của cột "ArrivalTime" (Column2) + cột "BurstTime" (Column3) vào cột "Complete" (Column4)
                        dataGridView1.Rows[i].Cells["Column4"].Value =
                        Convert.ToInt32(dataGridView1.Rows[i].Cells["Column2"].Value)
                        + Convert.ToInt32(dataGridView1.Rows[i].Cells["Column3"].Value);
                    }
                    else
                    {
                        // Ngược lại, gán giá trị của cột "Complete" (Column4) của dòng trước đó + cột "BurstTime" (Column3) vào cột "Complete" (Column4)
                        dataGridView1.Rows[i].Cells["Column4"].Value =
                        Convert.ToInt32(dataGridView1.Rows[i - 1].Cells["Column4"].Value)
                        + Convert.ToInt32(dataGridView1.Rows[i].Cells["Column3"].Value);
                    }
                }

                // Tính giá trị cột "Turnaround" (Column5) = cột "Complete" (Column4) - cột "ArrivalTime" (Column2)
                dataGridView1.Rows[i].Cells["Column5"].Value =
                        Convert.ToInt32(dataGridView1.Rows[i].Cells["Column4"].Value)
                        - Convert.ToInt32(dataGridView1.Rows[i].Cells["Column2"].Value);

                // Tính giá trị cột "Waiting" (Column6) = cột "Turnaround" (Column5) - cột "BurstTime" (Column3)
                dataGridView1.Rows[i].Cells["Column6"].Value =
                        Convert.ToInt32(dataGridView1.Rows[i].Cells["Column5"].Value)
                        - Convert.ToInt32(dataGridView1.Rows[i].Cells["Column3"].Value);

                // Tính tổng của cột "Waiting" (Column6) để tính trung bình của wt (waiting time)
                avgwt1 += Convert.ToInt32(dataGridView1.Rows[i].Cells["Column6"].Value);

                // Tính tổng của cột "Turnaround" (Column5) để tính trung bình của ta (turnaround time)
                avgta1 += Convert.ToInt32(dataGridView1.Rows[i].Cells["Column5"].Value);
            }

            // Đặt giá trị trung bình của ta (turnaround time) vào thành phần Text của avgta
            avgta.Text = (avgta1 / n).ToString();

            // Đặt giá trị trung bình của wt (waiting time) vào thành phần Text của avgwt
            avgwt.Text = (avgwt1 / n).ToString();
        }

        // Hàm tạo số lượng project tương ứng muôn
        private void Create_Click(object sender, EventArgs e)
        {
            if (n == 0)
            {
                // Nếu giá trị của biến n là 0, tức là chưa có hàng nào trong dataGridView1

                n = numericUpDown1.Value; // Gán giá trị của numericUpDown1 vào biến n

                for (int i = 0; i < numericUpDown1.Value; i++)
                {
                    // Thêm một hàng mới vào bảng
                    dataGridView1.Rows.Add();

                    // Thiết lập giá trị cho từng ô trong hàng

                    // Giả sử cột "PID" đã được tạo trước đó
                    dataGridView1.Rows[i].Cells["Column1"].Value = i + 1;

                    // Giả sử cột "ArrivalTime" đã được tạo trước đó
                    dataGridView1.Rows[i].Cells["Column2"].Value = 0;

                    // Giả sử cột "BurstTime" đã được tạo trước đó
                    dataGridView1.Rows[i].Cells["Column3"].Value = 0;

                    // Giả sử cột "Complete" đã được tạo trước đó
                    dataGridView1.Rows[i].Cells["Column4"].Value = 0;

                    // Giả sử cột "Turnaround" đã được tạo trước đó
                    dataGridView1.Rows[i].Cells["Column5"].Value = 0;

                    // Giả sử cột "Waiting" đã được tạo trước đó
                    dataGridView1.Rows[i].Cells["Column6"].Value = 0;
                }
            }
            else
            {
                // Nếu giá trị của biến n không phải là 0, tức là đã có hàng trong dataGridView1

                if (n < numericUpDown1.Value)
                {
                    // Nếu giá trị của biến n nhỏ hơn giá trị củanumericUpDown1.Value, tức là số hàng hiện tại ít hơn số hàng mới được yêu cầu

                    for (int i = Convert.ToInt32(n); i < numericUpDown1.Value; i++)
                    {
                        // Thêm một hàng mới vào bảng
                        dataGridView1.Rows.Add();

                        // Thiết lập giá trị cho từng ô trong hàng

                        // Giả sử cột "PID" đã được tạo trước đó
                        dataGridView1.Rows[i].Cells["Column1"].Value = i + 1;

                        // Giả sử cột "ArrivalTime" đã được tạo trước đó
                        dataGridView1.Rows[i].Cells["Column2"].Value = 0;

                        // Giả sử cột "BurstTime" đã được tạo trước đó
                        dataGridView1.Rows[i].Cells["Column3"].Value = 0;

                        // Giả sử cột "Complete" đã được tạo trước đó
                        dataGridView1.Rows[i].Cells["Column4"].Value = 0;

                        // Giả sử cột "Turnaround" đã được tạo trước đó
                        dataGridView1.Rows[i].Cells["Column5"].Value = 0;

                        // Giả sử cột "Waiting" đã được tạo trước đó
                        dataGridView1.Rows[i].Cells["Column6"].Value = 0;
                    }

                    n = numericUpDown1.Value; // Cập nhật giá trị của biến n
                }
                else if (n > numericUpDown1.Value)
                {
                    // Nếu giá trị của biến n lớn hơn giá trị của numericUpDown1.Value, tức là số hàng hiện tại lớn hơn số hàng mới được yêu cầu

                    for (int i = Convert.ToInt32(n - 1); i > numericUpDown1.Value - 1; i--)
                    {
                        // Xóa hàng khỏi bảng
                        dataGridView1.Rows.Remove(dataGridView1.Rows[i]);
                    }

                    n = numericUpDown1.Value; // Cập nhật giá trị của biến n
                }
            }
        }

        // chuyển sang form fcfs
        private void button11_Click(object sender, EventArgs e)
        {
            Hide(); // Ẩn form hiện tại

            // Tạo một thể hiện mới của lớp fcfs
            fcfs form = new fcfs();

            // Gọi phương thức LayDuLieuTuDataGridView() để lấy dữ liệu từ DataGridView và gán vào một đối tượng DataTable có tên duLieuTuDataGridView
            DataTable duLieuTuDataGridView = LayDuLieuTuDataGridView();

            // Gọi phương thức NhanDuLieuTuFormGoc() trên đối tượng form và truyền vào đối số duLieuTuDataGridView, để chuyển dữ liệu từ form gốc sang form mới (fcfs)
            form.NhanDuLieuTuFormGoc(duLieuTuDataGridView);

            // Hiển thị form mới (fcfs) dưới dạng hộp thoại chờ và ngăn chặn người dùng tương tác với form gốc cho đến khi form fcfs được đóng
            form.ShowDialog();

            // Đặt kết quả của hộp thoại thành DialogResult.OK. Điều này cho biết rằng hộp thoại đã được đóng một cách thành công và trạng thái trả về là OK.
            DialogResult = DialogResult.OK;

            Close(); // Đóng form hiện tại
        }

        // chuyển sang form rr
        private void button10_Click(object sender, EventArgs e)
        {
            Hide(); // Ẩn form hiện tại

            // Tạo một thể hiện mới của lớp rr
            rr form = new rr();

            // Gọi phương thức LayDuLieuTuDataGridView() để lấy dữ liệu từ DataGridView và gán vào một đối tượng DataTable có tên duLieuTuDataGridView
            DataTable duLieuTuDataGridView = LayDuLieuTuDataGridView();

            // Gọi phương thức NhanDuLieuTuFormGoc() trên đối tượng form và truyền vào đối số duLieuTuDataGridView, để chuyển dữ liệu từ form gốc sang form mới (rr)
            form.NhanDuLieuTuFormGoc(duLieuTuDataGridView);

            // Hiển thị form mới (rr) dưới dạng hộp thoại chờ và ngăn chặn người dùng tương tác với form gốc cho đến khi form rr được đóng
            form.ShowDialog();

            // Đặt kết quả của hộp thoại thành DialogResult.OK. Điều này cho biết rằng hộp thoại đã được đóng một cách thành công và trạng thái trả về là OK.
            DialogResult = DialogResult.OK;

            Close(); // Đóng form hiện tại
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Hide(); // Ẩn form hiện tại

            // Tạo một thể hiện mới của lớp sjf
            sjf form = new sjf();

            // Gọi phương thức LayDuLieuTuDataGridView() để lấy dữ liệu từ DataGridView và gán vào một đối tượng DataTable có tên duLieuTuDataGridView
            DataTable duLieuTuDataGridView = LayDuLieuTuDataGridView();

            // Gọi phương thức NhanDuLieuTuFormGoc() trên đối tượng form và truyền vào đối số duLieuTuDataGridView, để chuyển dữ liệu từ form gốc sang form mới (sjf)
            form.NhanDuLieuTuFormGoc(duLieuTuDataGridView);

            // Hiển thị form mới (sjf) dưới dạng hộp thoại chờ và ngăn chặn người dùng tương tác với form gốc cho đến khi form sjf được đóng
            form.ShowDialog();

            // Đặt kết quả của hộp thoại thành DialogResult.OK. Điều này cho biết rằng hộp thoại đã được đóng một cách thành công và trạng thái trả về là OK.
            DialogResult = DialogResult.OK;

            Close(); // Đóng form hiện tại
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Hide(); // Ẩn form hiện tại

            // Tạo một thể hiện mới của lớp srtn
            srtn form = new srtn();

            // Gọi phương thức LayDuLieuTuDataGridView() để lấy dữ liệu từ DataGridView và gán vào một đối tượng DataTable có tên duLieuTuDataGridView
            DataTable duLieuTuDataGridView = LayDuLieuTuDataGridView();

            // Gọi phương thức NhanDuLieuTuFormGoc() trên đối tượng form và truyền vào đối số duLieuTuDataGridView, để chuyển dữ liệu từ form gốc sang form mới (srtn)
            form.NhanDuLieuTuFormGoc(duLieuTuDataGridView);

            // Hiển thị form mới (srtn) dưới dạng hộp thoại chờ và ngăn chặn người dùng tương tác với form gốc cho đến khi form srtn được đóng
            form.ShowDialog();

            // Đặt kết quả của hộp thoại thành DialogResult.OK. Điều này cho biết rằng hộp thoại đã được đóng một cách thành công và trạng thái trả về là OK.
            DialogResult = DialogResult.OK;

            Close(); // Đóng form hiện tại
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Thoát khỏi ứng dụng
            Application.Exit();
        }
    }
}