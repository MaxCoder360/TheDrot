using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using myBestShop.Utils;

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
        public int columnCount = 3;
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
        private List<Label> cells = new List<Label>();
        private List<ComputerWrapper> computerStatuses;
        public TableViewHolder(int width, int height, int locX, int locY)
        {
            this.width = width;
            this.height = height;
            this.locX = locX;
            this.locY = locY;
        }

        public TableViewHolder changeColumnCount(int newColumnCount)
        {
            columnCount = newColumnCount;
            return this;
        }

        public TableViewHolder appendCellsWithStatuses(List<ComputerWrapper> comps)
        {
            computerStatuses = comps;
            appendCellRange(comps.Count);
            return this;
        }

        public TableViewHolder appendCellRange(int count)
        {
            int rowInd = (cellCount) / columnCount;
            int colInd = cellCount % columnCount;
            while (count != 0)
            {
                Logger.println(rowInd.ToString() + " : " + colInd.ToString());
                addCell(rowInd, colInd);

                if (++colInd == columnCount)
                {
                    colInd = 0;
                    rowInd++;
                }
                count--;
            }

            return this;
        }

        public TableViewHolder addCell(int rowInd, int colInd)
        {
            int pos = rowInd * columnCount + colInd;
            var box = new Label();
            if (pos >= cells.Count)
            {
                cells.Add(box);
            } else
            {
                cells.Insert(pos, box);
            }

            return this;
        }

        public TableViewHolder removeCell(int rowInd, int colInd)
        {
            int pos = rowInd * columnCount + colInd;
            cells.RemoveAt(pos);

            return this;
        }

        public TableViewHolder clear()
        {
            cells.Clear();

            return this;
        }

        public List<List<Label>> getCells()
        {
            var result = new List<List<Label>>();
            int rowsCount = (cellCount + columnCount - 1) / columnCount;

            int pos = 0;

            for (int i = 0; i < rowsCount; i++)
            {
                result.Add(new List<Label>());
                int locX = this.locX;
                int locY = this.locY + i * cellHeight;
                for (int j = 0; j < columnCount; j++)
                {
                    if (pos == cellCount)
                    {
                        return result;
                    }
                    result[i].Add(updateCell(cells[i * columnCount + j], locX, locY, i * columnCount + j, computerStatuses[pos].convertStatusToDataGridStyle()));
                    locX += cellWidth;
                    pos++;
                }
            }

            return result;
        }

        public List<Label> getReducedCells()
        {
            return cells;
        }

        private Label updateCell(Label box, int locX, int locY, int index, Color backColor)
        {
            box.Width = cellWidth;
            box.Height = cellHeight;
            box.Text = "Computer " + index.ToString();
            box.BorderStyle = BorderStyle.FixedSingle;
            box.BackColor = backColor;
            box.Location = new System.Drawing.Point(locX, locY);

            return box;
        }
    }
}
