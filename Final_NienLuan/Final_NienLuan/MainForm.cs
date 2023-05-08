using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing.Drawing2D;
using System;
using System.Windows.Forms;
using System.Net;
using System.Security.Cryptography;

namespace Final_NienLuan
{
    public partial class MainForm : Form
    {
        DrawControl draw_control;
        Graph graph;
        bool is_dragging;
        bool is_changed_location;
        Point start_point;
        Point end_point;
        Node selected_node;
        public MainForm()
        {
            InitializeComponent();
            draw_control = new DrawControl();
            Enabel(false);
          
        }

        /// <summary>
        /// Kích hoạt và hủy kích hoạt các chức năng/control trong giao diện
        /// </summary>
        /// <param name="enable">Tham số kích hoạt</param>
        public void Enabel(bool status) 
        {
            btnCal.Enabled = status;
            btnDFS.Enabled = status;
            btnShow.Enabled = status;
            btnClear.Enabled = status;
            btnReset.Enabled = status;
            btnShow.Enabled = status;
            saveFileToolStripMenuItem.Enabled = status;
        }

        /// <summary>
        /// Vẽ đồ thị ra Panel 
        /// </summary>
        private void drawPanel_Paint(object sender, PaintEventArgs e)
        {

            Font font = new Font(Font.Name, draw_control.NODE_RADIUS, FontStyle.Bold);
            Font weigh_font = new Font(Font.Name, draw_control.NODE_RADIUS - 5, FontStyle.Bold);

            foreach (Edge edge in draw_control.edges)
            {
                e.Graphics.DrawLine(new Pen(edge.Color_Edge, 2), edge.Start_Node.X, edge.Start_Node.Y, edge.End_Node.X, edge.End_Node.Y);
                e.Graphics.DrawString(edge.Weight.ToString(), weigh_font, Brushes.Black, (edge.Start_Node.X + edge.End_Node.X) / 2, (edge.Start_Node.Y + edge.End_Node.Y) / 2);
            }

            foreach (Node node in draw_control.nodes)
            {
                e.Graphics.FillEllipse(node.Node_Fill_Color, node.X - draw_control.NODE_RADIUS, node.Y - draw_control.NODE_RADIUS, draw_control.NODE_RADIUS * 2, draw_control.NODE_RADIUS * 2);
                e.Graphics.DrawString(node.Label.ToString(), font, Brushes.Black, node.X - draw_control.NODE_RADIUS / 2, node.Y + 5);
            }

            if(is_dragging)
            {
                Pen pen = new Pen(Color.Teal, 2);
                e.Graphics.DrawLine(pen, start_point, end_point);
                pen.Dispose();
            }
        }


        void Update_data()
        {
            if (draw_control.nodes.Count > 0)
            {
                graph = new Graph(draw_control.nodes.Count);

                foreach (Edge edge in draw_control.edges)
                {
                    int startNode = Convert.ToInt16(edge.Start_Node.Label);
                    int endNode = Convert.ToInt16(edge.End_Node.Label);
                    int weight = edge.Weight;
                    graph.Add_Edge(startNode, endNode, weight);
                }

                Enabel(true);
            }
        }

        /// <summary>
        /// Nhập vào trọng số cung
        /// </summary>
        /// <param name="edge">Cung cần nhập trọng số</param>
        /// <param name="title">Tiêu đề form nhập</param>
        /// <param name="content">Nội dung form nhập</param>
        private void Entered_Weight(Edge edge, string title, string content)
        {
            do
            {

                string newWeightString = Microsoft.VisualBasic.Interaction.InputBox(
                    title,
                    content,
                    edge.Weight.ToString()
                );

                try
                {
                    edge.Weight = int.Parse(newWeightString);
                    if (edge.Weight < 0)
                    {
                        MessageBox.Show("Vui lòng nhập trọng số là một số nguyên dương!");
                        continue;
                    }
                    if (edge.Weight == 0)
                    {
                        if (draw_control.edges.Contains(edge))
                        {
                            draw_control.edges.Remove(edge);
                        }
                            
                        else
                        {
                            MessageBox.Show("Vui lòng nhập trọng số là một số nguyên dương!");
                            continue;
                        }
                    }

                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Vui lòng nhập trọng số là một số nguyên dương!");
                }
            } while (true);
        }

 
        /// <summary>
        /// Xử lý sự kiện khi click vào nút Khôi phục
        /// 1. Thay đổi màu của các cung và nút về mặc định
        /// 2. Kích hoạt nút Xác định để Xác định cây khung nhỏ nhất
        /// </summary>
        private void btnReset_Click(object sender, EventArgs e)
        {
            draw_control.Reset_Color();

            btnShow.Enabled = true;
            
            Refresh();
        }

        /// <summary>
        /// Xứ lý sự kiện khi click vào nút Xóa tất cả
        /// 1. Xóa tất cả đỉnh và cung trong danh sách đỉnh và danh sách cung
        /// 2. Khởi tạo Start_Node và End_Node bằng null
        /// 3. Hủy kích hoạt các chức năng liên quan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            draw_control.edges.Clear();
            draw_control.nodes.Clear();
            draw_control.Start_Node = null;
            draw_control.End_Node = null;
            Update_data();
            Enabel(false);
            Refresh();
        }

        /// <summary>
        /// Hiển thị form nhập đỉnh bắt đầu
        /// </summary>
        /// <returns>Trả về chuỗi chứa nhãn của đỉnh bắt đầu</returns>
        private string Input_Begin_Node_Form()
        {
            string input_string = "";

            ComboBox comboBox = new ComboBox();
            Form input_form = new Form();
            input_form.Text = "Đỉnh bắt đầu: ";
            input_form.Height = 150;
            input_form.Width = 350;
            input_form.StartPosition = FormStartPosition.CenterScreen;
            comboBox.Parent = input_form;
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox.Width = 200;
            comboBox.Location = new Point(20, 20);
            for(int i = 1; i <= graph.n; i++)
                comboBox.Items.Add(i);
            Button okButton = new Button();
            okButton.Parent = input_form;
            okButton.Text = "Duyệt";
            okButton.DialogResult = DialogResult.OK;
            okButton.Height = 30;
            okButton.Location = new Point(50, 50);
            Button cancelButton = new Button();
            cancelButton.Parent = input_form;
            cancelButton.Height = 30;
            cancelButton.Text = "Thoát";
            cancelButton.DialogResult = DialogResult.Cancel;
            cancelButton.Location = new Point(130, 50);
            input_form.AcceptButton = okButton;
            input_form.CancelButton = cancelButton;

            //Hiển thị MessageBox tùy chỉnh và lấy giá trị được nhập vào nếu người dùng nhấn OK
            if (input_form.ShowDialog() == DialogResult.OK)
            {
                input_string = comboBox.SelectedIndex + 1 + "";
            }
            else
            {
                input_form.Close();
                return "close";
            }
                

            return input_string;
        }

        /// <summary>
        /// Xử lý chức năng khi click vào nút Duyệt
        /// 1. Hiển thị form nhập đỉnh bắt đầu
        /// 2. Duyệt đồ thị từ đỉnh bắt đầu được chọn
        /// 3. Hiển thị kết quả ra ô kết quả
        /// </summary>

        private void btnDFS_Click(object sender, EventArgs e)
        {
            if (graph == null || graph.n <= 0)
                return;

            do
            {
                string input_string = Input_Begin_Node_Form();

                if (input_string == "close")
                    break;

                //Kiểm tra xem người dùng đã nhập chuỗi hay chưa
                if (input_string != "")
                {
                    int inputNode = -1;
                    try
                    {
                        inputNode = int.Parse(input_string);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Vui lòng nhập số từ 1 đến " + graph.n.ToString());
                        continue;
                    }
                        

                    List<int> result = this.graph.DFS(inputNode);

                    string result_dfs = "";
                    for (int i = 0; i < result.Count; i++)
                        result_dfs += result[i].ToString() + " ";


                    lb_DFS_result.Text = result_dfs;
                    break;
                }
            } while (true);
        }

        private Color[] RandomColor()
        {
            Color[] colors = new Color[10];

            Random random = new Random();
            List<Color> usedColors = new List<Color>();

            for (int i = 0; i < 10; i++)
            {
                Color color;
                do
                {
                    int red = random.Next(256);
                    int green = random.Next(256);
                    int blue = random.Next(256);

                    color = Color.FromArgb(red, green, blue);
                } while (usedColors.Contains(color));

                colors[i] = color;
                usedColors.Add(color);
            }

            return colors;

        }

        private void btnCal_Click(object sender, EventArgs e)
        {
            Color[] colors = RandomColor();
            int i = 0;

            foreach(List<int> combonent in graph.Number_Of_Connected_Components())
            {
       
                Brush brush = new SolidBrush(colors[i]);
                foreach(int label in combonent)
                {
                    selected_node = draw_control.Get_Node_At(label);
                    selected_node.Node_Fill_Color = brush;
                }
                i++;
            }

            Refresh();

            lb_number_cc.Text = graph.Number_Of_Connected_Components().Count.ToString();
            selected_node = null;
        }

        /// <summary>
        /// Xử lý sự kiện khi click vào nút Xác định
        /// 1. Xác định cây khung nhỏ nhất
        /// 2. Tô màu các đỉnh và cung trong cây khung
        /// 3. Kích hoạt chức năng Khôi phục
        /// </summary>
        private void btnShow_Click(object sender, EventArgs e)
        {
            if (graph.Number_Of_Connected_Components().Count == 1)
            {
                int[] prim = this.graph.Prim();

                draw_control.Set_Result_Color(prim);


                Refresh();
            }
            else
                MessageBox.Show("Không thể tính cây khung tối thiểu");
        }

        /// <summary>
        /// Xử lý sự kiện khi click vào Lưu đồ thị
        /// 1. Hiện Save File Dialog cho thông tin file lưu trữ
        /// 2. Lưu thông tin đồ thị vào file .txt
        /// 3. Lưu thông tin thiết kế đồ thị vào file .txtd
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(graph != null)
            {
                save_file_dialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                save_file_dialog.Title = "Lưu đồ thị";
                save_file_dialog.ShowDialog();


                string path = save_file_dialog.FileName;
                string content = "";
                string content_nd = "";

                content += this.graph.n.ToString() + "\n";
                content_nd += content;

                foreach (Node node in draw_control.nodes)
                {
                    content_nd += node.X + " " + node.Y + " " + node.Label + "\n";
                }

                foreach (Edge edge in draw_control.edges)
                {
                    content += edge.Start_Node.Label + " " + edge.End_Node.Label + " " + edge.Weight.ToString() + '\n';
                    content_nd += edge.Start_Node.Label + " " + edge.End_Node.Label + " " + edge.Weight + "\n";
                }



                if (path != "")
                {
                    File.WriteAllText(path, content);
                    File.WriteAllText(path + "d", content_nd);
                }
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi click chức năng Mở đồ thị
        /// 1. Hiện Open File Dialog cho chọn file .txtd
        /// 2. Đọc thông tin và xử lý file được chọn
        /// 3. Hiển thị đồ thị ra panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            open_file_dialog.Filter = "Text Files (*.txtd)|*.txtd|All Files (*.*)|*.*";
            open_file_dialog.Title = "Mở đồ thị";
            open_file_dialog.ShowDialog();
            draw_control.edges.Clear();
            draw_control.nodes.Clear();
            int count = 0;
            Node begin_node = new Node();
            Node end_node = new Node();
            string[] number;

            if (open_file_dialog.FileName != "")
            {
                string[] lines = File.ReadAllLines(open_file_dialog.FileName);

                count = Convert.ToInt16(lines[0]);
   
                for(int i = 1; i <= count; i++)
                {

                    number = lines[i].Split(' ');

                    Node node = new Node()
                    {
                        X = Convert.ToInt16(number[0]),
                        Y = Convert.ToInt16(number[1]),
                        Label = Convert.ToInt16(number[2]),
                        Node_Fill_Color = Brushes.Teal
                    };

                    draw_control.nodes.Add(node);
                }

                for(int i = count+1; i < lines.Length; i++)
                {
                    number = lines[i].Split(' ');
                    begin_node = draw_control.Get_Node_At(Convert.ToInt16(number[0]));
                    end_node = draw_control.Get_Node_At(Convert.ToInt16(number[1]));

                    Edge edge = new Edge()
                    {
                        Start_Node = begin_node,
                        End_Node = end_node,
                        Weight = Convert.ToInt16(number[2]),
                        Color_Edge = Color.Teal
                    };

                    draw_control.edges.Add(edge);
                }

                Update_data();
                Refresh();
            }

        }
        /// <summary>
        /// Hiển thị form thông tin phần mềm
        /// </summary>
        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InfoForm frm = new InfoForm();
            frm.Show();
        }

        private void drawPanel_MouseDown(object sender, MouseEventArgs e)
        {
  
            if(e.Button == MouseButtons.Left)
            {
                if(!is_changed_location)
                {
                    if(draw_control.Get_Node_At(e.Location) != null)
                    {
                        start_point = e.Location;
                        is_dragging = true;
                    }
                }
                else
                {
                    if (draw_control.Get_Node_At(e.Location) != null)
                    {
                        selected_node = draw_control.Get_Node_At(e.Location);
                        is_dragging = true;
                    }
                }

            }
            
        }

        private void drawPanel_MouseMove(object sender, MouseEventArgs e)
        {

            if (is_dragging)
            {
                if(!is_changed_location)
                {
                    end_point = e.Location;
                }
                else
                {
                    selected_node.X = e.Location.X;
                    selected_node.Y = e.Location.Y;
                    
                }
                Refresh();
            }
            
            
        }

        private void drawPanel_MouseUp(object sender, MouseEventArgs e)
        {
            
            if (is_dragging)
            {
                is_dragging = false;
                if (!is_changed_location)
                {
                    end_point = e.Location;
                    

                    draw_control.Start_Node = draw_control.Get_Node_At(start_point);
                    draw_control.End_Node = draw_control.Get_Node_At(end_point);

                    if (draw_control.Start_Node != null && draw_control.End_Node != null && draw_control.Start_Node != draw_control.End_Node)
                    {
                        Edge selected_edge = draw_control.Get_Edge_Of(draw_control.Start_Node, draw_control.End_Node);
                        if (selected_edge == null)
                        {
                            Edge edge = new Edge()
                            {
                                Start_Node = draw_control.Start_Node,
                                End_Node = draw_control.End_Node,
                                Weight = 0,
                                Color_Edge = Color.Teal
                            };

                            Entered_Weight(edge, "Nhập giá trị cho trọng số của cung: " + draw_control.Start_Node.Label + " - " + draw_control.End_Node.Label, "Thêm trọng số cung");

                            draw_control.edges.Add(edge);
                        }
                        else
                        {
                            Entered_Weight(selected_edge, "Thay đổi giá trị cho trọng số của cung: " + draw_control.Start_Node.Label + " - " + draw_control.End_Node.Label, "Thay đổi trọng số cung");
                        }
                        drawPanel.Invalidate();
                    }
                }
                start_point = end_point ;
                Refresh();
                Update_data();
            }
            
        }

        private void drawPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if(!is_changed_location)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (draw_control.Get_Node_At(e.Location) == null)
                    {
                        Node node = new Node()
                        {
                            X = e.X,
                            Y = e.Y,
                            Label = (draw_control.nodes.Count + 1),
                            Node_Fill_Color = Brushes.Teal
                        };

                        draw_control.nodes.Add(node);

                    }

                }
                if (e.Button == MouseButtons.Right)
                {
                    Node clicked_node = draw_control.Get_Node_At(e.Location);

                    //Nếu tồn tại đỉnh tại vị trí click thì thực hiện xóa đỉnh và các cung được nối với đỉnh đó
                    if (clicked_node != null)
                    {
                        List<Edge> deleEdge = new List<Edge>();
                        foreach (Edge edge in draw_control.edges)
                        {
                            if (edge.Start_Node == clicked_node || edge.End_Node == clicked_node)
                                deleEdge.Add(edge);
                        }
                        foreach (Edge edge in deleEdge)
                        {
                            draw_control.edges.Remove(edge);
                        }
                        draw_control.Update_Label(clicked_node);
                        draw_control.nodes.Remove(clicked_node);
                    }
                }
                Update_data();
                Refresh();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            btnChangeLocation.Enabled = true;
            btnUpdate.Enabled = false;
            is_changed_location = false;

        }

        private void btnChangeLocation_Click(object sender, EventArgs e)
        {
            btnUpdate.Enabled = true;
            btnChangeLocation.Enabled = false;
            is_changed_location = true;
        }
    }
}