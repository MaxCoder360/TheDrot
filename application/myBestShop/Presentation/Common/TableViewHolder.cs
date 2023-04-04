using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace myBestShop.Presentation.Common
{
    public class TableViewHolder
    {
        public int cellCount
        {
            get
            {
                return cells.Count;
            }
        }
        public int columnCount = 1;
        public int rowCount
        {
            get
            {
                return (cellCount + columnCount - 1) / columnCount;
            }
        }
        public int width = 0;
        public int height = 0;
        public int locX = 0;
        public int locY = 0;

        private int cellWidth 
        { 
            get
            {
                return width / columnCount;
            } 
        }
        private int cellHeight
        {
            get
            {
                return height / ((cellCount + columnCount - 1) / columnCount);
            }
        }
        private List<TextBox> cells = new List<TextBox>();
        private Form rootComponent = null;
        public TableViewHolder(Form root, int width, int height, int locX, int locY)
        {
            rootComponent = root;
            this.width = width;
            this.height = height;
            this.locX = locX;
            this.locY = locY;
        }

        public void appendCellRange(int count)
        {
            int rowInd = rowCount-1;
            int colInd = cellCount % columnCount;
        }

        public void addCell(int rowInd, int colInd)
        {
            int pos = rowInd * columnCount + colInd;
            var box = new TextBox();
            if (pos >= cells.Count)
            {
                cells.Add(box);
            } else
            {
                cells.Insert(pos, box);
            }
        }

        public void removeCell(int rowInd, int colInd)
        {
            int pos = rowInd * columnCount + colInd;
            cells.RemoveAt(pos);
        }

        public void clear()
        {
            cells.Clear();
        }

        public List<List<TextBox>> getCells()
        {
            var result = new List<List<TextBox>>();
            int rowsCount = (cellCount + columnCount) / columnCount;

            for (int i = 0; i < rowsCount; i++)
            {
                result.Add(new List<TextBox>());
                int locX = this.locX;
                int locY = this.locY + i * cellHeight;
                for (int j = 0; j < columnCount; j++)
                {
                    result[i].Append(updateCell(cells[i * rowsCount + j], locX, locY));
                    locX += cellWidth;
                }
            }

            return result;
        }

        private TextBox updateCell(TextBox box, int locX, int locY)
        {
            box.Width = cellWidth;
            box.Height = cellHeight;
            box.Text = "ajjjajas";
            box.Location = new Point(locX, locY);

            return box;
        }
    }
}
