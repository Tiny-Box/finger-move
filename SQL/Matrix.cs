using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL
{
    class Matrix
    {
        private double[,] matrix; //建立二维数组
        private int col; //矩阵的列数
        private int row; //矩阵的行数
        private string name; //矩阵名字

        //构造函数
        public Matrix(int row, int col)
        {
            this.col = col;
            this.row = row;
            this.name = "";
            this.matrix = new double[row, col];
        }
        public Matrix(int row, int col, string name)
        {
            this.col = col;
            this.row = row;
            this.name = name;
            this.matrix = new double[row, col];
        }
        public Matrix(int row, int col, double[] data)
        {
            this.col = col;
            this.row = row;
            this.name = "";
            this.matrix = new double[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    this.matrix[i, j] = data[i * col + j];
                }
            }
        }
        public Matrix(int row, int col, string name, double[] data)
        {
            this.col = col;
            this.row = row;
            this.name = name;
            this.matrix = new double[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    this.matrix[i, j] = data[i * col + j];
                }
            }
        }
        public Matrix(int row, int col, double[,] data)
        {
            this.col = col;
            this.row = row;
            this.matrix = new double[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    this.matrix[i, j] = data[i, j];
                }
            }
        }
        public Matrix(int row, int col, string name, double[,] data)
        {
            this.col = col;
            this.row = row;
            this.name = name;
            this.matrix = new double[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    this.matrix[i, j] = data[i, j];
                }
            }
        }

        //获取参数
        public int Column
        {
            get { return col; }
            set { this.col = value; }
        }
        public int Rows
        {
            get { return row; }
            set { this.row = value; }
        }
        public string Name
        {
            get { return name; }
            set { this.name = value; }
        }

        //输出矩阵
        public string Show()
        {
            string show = "";
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    show = show + matrix[i, j].ToString() + " ";
                }
                show = show + "\n";
            }
            return show;
        }

        //取某个值
        public double GetValue(int i, int j)
        {
            return this.matrix[i, j];
        }

        //初等变换：矩阵第i行乘以常数
        public Matrix MulCount(int i, double count)
        {
            for (int j = 0; j < col; j++)
            {
                this.matrix[i, j] *= count;
            }
            return this;
        }

        //转置
        public Matrix Transpose()
        {
            int rows = this.col;
            int cols = this.row;
            Matrix trans = new Matrix(rows, cols);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    trans.matrix[i, j] = this.matrix[j, i];
                }
            }
            return trans;
        }

        //转换为数组
        public double[,] ToArray()
        {
            double[,] temp = new double[this.row, this.col];
            for (int i = 0; i < this.row; i++)
            {
                for (int j = 0; j < this.col; j++)
                {
                    temp[i, j] = this.matrix[i, j];
                }
            }
            return temp;
        }

        //矩阵相加
        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            if (m1.row != m2.row || m1.col != m2.col)
            {
                System.Exception e = new Exception("两矩阵的行数或者列数不相等!");
                throw e;
            }
            Matrix mat = new Matrix(m1.row, m2.col);
            for (int i = 0; i < m1.row; i++)
            {
                for (int j = 0; j < m1.col; j++)
                {
                    mat.matrix[i, j] = m1.matrix[i, j] + m2.matrix[i, j];
                }
            }
            return mat;
        }
        //矩阵相减
        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            if (m1.row != m2.row || m1.col != m2.col)
            {
                System.Exception e = new Exception("两矩阵的行数或者列数不相等!");
                throw e;
            }
            Matrix mat = new Matrix(m1.row, m2.col);
            for (int i = 0; i < m1.row; i++)
            {
                for (int j = 0; j < m1.col; j++)
                {
                    mat.matrix[i, j] = m1.matrix[i, j] - m2.matrix[i, j];
                }
            }
            return mat;
        }
        //矩阵相乘
        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            if (m1.col != m2.row)
            {
                System.Exception e = new Exception("两矩阵的行列数不同!");
                throw e;
            }
            Matrix mat = new Matrix(m1.row, m2.col);
            for (int i = 0; i < m1.row; i++)
            {
                for (int j = 0; j < m2.col; j++)
                {
                    double temp = 0;
                    for (int k = 0; k < m1.col; k++)
                    {
                        temp += m1.matrix[i, k] * m2.matrix[k, j];
                    }
                    mat.matrix[i, j] = temp;
                }
            }
            return mat;
        }

        //矩阵求逆
        public Matrix converse()
        {
            if (this.row != this.col)
            {
                System.Exception e = new Exception("两矩阵的行列数不同!");
                throw e;
            }
            Matrix c = new Matrix(this.row, this.col);
            for (int i = 0; i < this.row; i++)
            {
                for (int j = 0; j < this.col; j++)
                {
                    if (i == j) { c.matrix[i, j] = 1; }
                    else { c.matrix[i, j] = 0; }
                }
            }

            //i表示第几行，j表示第几列
            for (int j = 0; j < this.row; j++)
            {
                bool flag = false;
                for (int i = j; i < this.row; i++)
                {
                    if (this.matrix[i, j] != 0)
                    {
                        flag = true;
                        double temp;
                        //交换i,j,两行
                        if (i != j)
                        {
                            for (int k = 0; k < this.row; k++)
                            {
                                temp = this.matrix[j, k];
                                this.matrix[j, k] = this.matrix[i, k];
                                this.matrix[i, k] = temp;

                                temp = c.matrix[j, k];
                                c.matrix[j, k] = c.matrix[i, k];
                                c.matrix[i, k] = temp;
                            }
                        }
                        //第j行标准化
                        double d = this.matrix[j, j];
                        for (int k = 0; k < this.row; k++)
                        {
                            this.matrix[j, k] = this.matrix[j, k] / d;
                            this.matrix[j, k] = this.matrix[j, k] / d;
                        }
                        //消去其他行的第j列
                        d = this.matrix[j, j];
                        for (int k = 0; k < this.row; k++)
                        {
                            if (k != j)
                            {
                                double t = this.matrix[k, j];
                                for (int n = 0; n < this.row; n++)
                                {
                                    this.matrix[k, n] -= (t / d) * this.matrix[j, n];
                                    c.matrix[k, n] -= (t / d) * c.matrix[j, n];
                                }
                            }
                        }
                    }
                }
                if (!flag) return null;
            }
            return c;
        }

        //矩阵归一化
        public Matrix normalize()
        {
            int rows = this.row;
            int cols = this.col;
            double sum = 0;

            Matrix trans = new Matrix(rows, 1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (i >= j)
                        this.matrix[i, j] = 1 / this.matrix[j, i];
                }
            }


            for (int j = 0; j < cols; j++)
            {
                for (int i = 0; i < rows; i++)
                    sum += this.matrix[i, j];
                for (int i = 0; i < rows; i++)
                    this.matrix[i, j] = this.matrix[i, j] / sum;
                sum = 0;
            }
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    trans.matrix[i, 0] += this.matrix[i, j];
            for (int i = 0; i < rows; i++)
            {
                sum += trans.matrix[i, 0];
            }
            for (int i = 0; i < rows; i++)
            {
                trans.matrix[i, 0] = trans.matrix[i, 0] / sum;
            }
            return trans;
        }
    }
}
