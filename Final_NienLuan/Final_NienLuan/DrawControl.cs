using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_NienLuan
{
    public class DrawControl
    {
        public List<Node> nodes;
        public List<Edge> edges;
        public int NODE_RADIUS = 15;

    public Node Start_Node
        {
            get; set;
        }

        public Node End_Node
        {
            get; set;
        }

        public DrawControl()
        {
            nodes = new List<Node>();
            edges = new List<Edge>();
        }

        /// <summary>
        /// Lấy đỉnh tại vị trí cho trước
        /// </summary>
        /// <param name="location">Vị trí cần lấy</param>
        /// <returns>Đỉnh được xác định, hoặc null nếu không tồn tại</returns>
        public Node Get_Node_At(Point location)
        {
            //Tìm đỉnh ở vị trí xác định trên màn hình
            foreach (Node node in nodes)
            {
                int node_size = 2 * NODE_RADIUS;
                Rectangle node_rect = new Rectangle(node.X - NODE_RADIUS, node.Y - NODE_RADIUS, node_size, node_size);

                if (node_rect.Contains(location))
                    return node;
            }

            return null;
        }

        /// <summary>
        /// Lấy đỉnh có nhãn bằng nhãn cho trước
        /// </summary>
        /// <param name="label">Nhãn cần lấy</param>
        /// <returns>Đỉnh được xác định, hoặc null nếu không tồn tại</returns>
        public Node Get_Node_At(int label)
        {
            foreach(Node node in nodes)
            {
                if (node.Label == label)
                    return node;
            }
            return null;
        }

        /// <summary>
        /// Trả về cung nối hai đỉnh cho trước
        /// </summary>
        /// <param name="start_node">Đỉnh thứ nhất</param>
        /// <param name="end_node">Đỉnh thứ hai</param>
        /// <returns>Cung được xác định, hoặc null nếu không tồn tại</returns>
        public Edge Get_Edge_Of(Node start_node, Node end_node)
        {
            foreach (Edge edge in edges)
            {
                if ((edge.Start_Node == start_node && edge.End_Node == end_node) || (edge.Start_Node == end_node && edge.End_Node == start_node))
                {
                    return edge;
                }
            }

            return null;
        }

        /// <summary>
        /// Trả về cung nối hai đỉnh cho trước với thông tin là nhãn của hai đỉnh
        /// </summary>
        /// <param name="start_node">Nhãn của đỉnh thứ nhất</param>
        /// <param name="end_node">Nhãn của đỉnh thứ hai</param>
        /// <returns>Cung được xác định, hoặc null nếu không tồn tại</returns>
        public Edge Get_Edge_Of(int start_node, int end_node)
        {
            foreach (Edge edge in edges)
            {
                if ((edge.Start_Node.Label == start_node && edge.End_Node.Label == end_node) || 
                    (edge.Start_Node.Label == end_node && edge.End_Node.Label == start_node))
                {
                    return edge;
                }
            }

            return null;
        }
        /// <summary>
        /// Cập nhật lại các nhãn của các định từ đỉnh truyền vào đến cuối
        /// </summary>
        /// <param name="node">Đỉnh bắt đầu cập nhật</param>
        public void Update_Label(Node node)
        {
            if (nodes.Count > 0)
            {
                int node_index = Convert.ToInt16(node.Label);

                for (int i = 0; i < nodes.Count; i++)
                {
                    int node_label = Convert.ToInt16(nodes[i].Label);

                    if (node_label > node_index)
                    {
                        node_label--;
                        nodes[i].Label = node_label;
                    }
                }
            }
        }

        public void Reset_Color()
        {
            foreach (Edge edge in edges)
                edge.Color_Edge = Color.Teal;

            foreach (Node node in nodes)
                node.Node_Fill_Color = Brushes.Teal;
        }

        public void Set_Result_Color(int[] prim)
        {

            foreach (Edge edge in edges)
            {
                edge.Color_Edge = Color.Gray;
            }


            for (int i = 1; i < prim.Length; i++)
            {
                Edge edge = Get_Edge_Of(i, prim[i]);

                if (edge == null)
                    continue;
                edge.Color_Edge = Color.Red;
                edge.Start_Node.Node_Fill_Color = Brushes.Red;
                edge.End_Node.Node_Fill_Color = Brushes.Red;

            }
        }
    }
}
