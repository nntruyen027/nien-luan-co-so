using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_NienLuan
{
    public class Graph
    {
        public int n;
        public int[,] G;

        public Graph(int num)
        {
            this.n = num;
            G = new int[n + 1, n + 1];

            for (int i = 1; i <= num; i++)
                for (int j = 1; j <= num; j++)
                    G[i, j] = 0;
        }

        /// <summary>
        /// Thêm cung
        /// </summary>
        /// <param name="node1">đỉnh thứ nhất</param>
        /// <param name="node2">đỉnh thứ hai</param>
        /// <param name="W">Trọng số cung</param>
        public void Add_Edge(int node1, int node2, int W)
        {
            G[node1, node2] = W;
            G[node2, node1] = W;
        }

        /// <summary>
        /// Kiểm tra kề
        /// </summary>
        /// <param name="node1">Đỉnh thứ nhất</param>
        /// <param name="node2">Đỉnh thứ hai</param>
        /// <returns>Trả về true nếu có cung nối hai đỉnh, ngược lại trả về false</returns>
        public bool Is_Adjacent(int node1, int node2)
        {
            return G[node1, node2] != 0;
        }

        /// <summary>
        /// Danh sách các đỉnh kề với đỉnh cho trước
        /// </summary>
        /// <param name="node">Đỉnh cần xác đỉnh</param>
        /// <returns>Danh sách các đỉnh kề</returns>
        public List<int> Neighbors(int node)
        {
            List<int> neighbors = new List<int>();
            for (int i = 1; i <= this.n; i++)
            {
                if (Is_Adjacent(node, i))
                    neighbors.Add(i);
            }

            return neighbors;
        }

        /// <summary>
        /// Duyệt theo chiều sâu với ngăn xếp
        /// </summary>
        /// <param name="start_node">Đỉnh bắt đầu duyệt</param>
        /// <returns>Danh sách kết quả theo thứ tự duyệt</returns>
        public List<int> DFS(int start_node)
        {
            List<int> dfs_result = new List<int>();

            bool[] visited = new bool[this.n + 1];
            Stack<int> stack = new Stack<int>();

            for (int i = 1; i <= this.n; i++)
                visited[i] = false;

            visited[start_node] = true;
            stack.Push(start_node);

            while (stack.Count > 0)
            {
                int current_node = stack.Pop();
                dfs_result.Add(current_node);

                List<int> neighbors = this.Neighbors(current_node);

                foreach (int neighbor in neighbors)
                {
                    if (!visited[neighbor])
                    {
                        visited[neighbor] = true;
                        stack.Push(neighbor);
                    }
                }

            }

            return dfs_result;

        }

        /// <summary>
        /// Xác định đỉnh có giá trị khóa nhỏ nhất chưa được thêm vào cây khung
        /// </summary>
        /// <param name="key">Giá trị khóa tương ứng với các đỉnh trong đồ thị</param>
        /// <param name="mst_set">Giá trị khóa tương ứng với các đỉnh thêm vào cây khung</param>
        /// <returns>Đỉnh có giá trị khóa nhỏ nhất chưa được thêm vào cây khung</returns>
        private int Min_Key(int[] key, bool[] mst_set)
        {
            int min = int.MaxValue;
            int min_node = 0;

            for (int i = 1; i <= n; i++)
                if (mst_set[i] == false && key[i] < min)
                {
                    min = key[i];
                    min_node = i;
                }

            return min_node;
        }


        /// <summary>
        /// Xác định cây khung tối thiểu của đồ thị vô hướng
        /// </summary>
        /// <returns>Mảng parent biểu hiện các cung của cây khung với trị số mảng và giá trị mảng 
        /// là các nút</returns>
        public int[] Prim()
        {
            int[] parent = new int[n + 1];
            int[] key = new int[n + 1];
            bool[] mst_set = new bool[n + 1];

            for (int i = 1; i <= n; i++)
            {
                key[i] = int.MaxValue;
                mst_set[i] = false;
            }

            key[1] = 0;
            parent[1] = 0;

            for (int count = 0; count < n; count++)
            {
                int u = Min_Key(key, mst_set);
                mst_set[u] = true;

                for (int i = 1; i <= n; i++)
                    if (G[u, i] != 0 && mst_set[i] == false && G[u, i] < key[i])
                    {
                        parent[i] = u;
                        key[i] = G[u, i];
                    }

            }

            return parent;
        }

        /// <summary>
        /// Xác định số thành phần liên thông trong đồ thị
        /// </summary>
        /// <returns>Số thành phần liên thông</returns>
        public List<List<int>> Number_Of_Connected_Components()
        {
            bool[] visted = new bool[this.n + 1];
            List<List<int>> result = new List<List<int>>();

            for (int i = 1; i <= this.n; i++)
                visted[i] = false;

            for (int i = 1; i <= this.n; i++)
            {
                if (!visted[i])
                {
                    
                    List<int> dfs_resut = this.DFS(i);
                    result.Add(dfs_resut);

                    foreach (int node in dfs_resut)
                        visted[node] = true;
                }
            }

            return result;
        }
    }

}
