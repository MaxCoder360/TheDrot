using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using myBestShop.Utils;
using myBestShop.Domain.Database.Delegates;

namespace myBestShop.Presentation.Common
{
    public class TableViewHolder
    {

        public static string controlItemNamePrefix = "status_element_";
        public static string statusItemNamePrefix = controlItemNamePrefix + "statusBox_";
        public static string infoItemNamePrefix = controlItemNamePrefix + "infoBox_";
        public static string cancelItemNamePrefix = controlItemNamePrefix + "cancelBox_";
        public static string hintItemNamePrefix = controlItemNamePrefix + "hintBox_";
        public int cellCount
        {
            get
            {
                return cells.Count;
            }
        }
        public int columnCount = 2;
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

        public List<Control> getCells()
        {
            var result = new List<Control>();
            int rowsCount = -1;

            for (int i = 0; i < cells.Count; i++)
            {
                if (i % columnCount == 0)
                {
                    rowsCount++;
                }
                int locX = this.locX + (i % columnCount) * cellWidth;
                int locY = this.locY + rowsCount * cellHeight;

                var decoratedCell = generateStatusCell(locX, locY, cellHeight, computerStatuses[i].convertStatusToTableViewFormat(),
                    "Computer id("+computerStatuses[i].computerId.ToString()+")");

                foreach (var box in decoratedCell)
                {
                    result.Add(box);
                }
            }

            return result;
        }

        [Obsolete("Method getCellsAsGrid() is deprecated due to inappropriate work with cells. Use getCells() method instead.")]
        public List<List<Label>> getCellsAsGrid()
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
                    result[i].Add(updateCell(cells[i * columnCount + j], locX, locY, i * columnCount + j, computerStatuses[pos].convertStatusToTableViewFormat().first));
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

        private List<Control> generateStatusCell(int begX, int begY, int cellHeight, Pair<Color, string> statusData, string information)
        {
            var backColor = statusData.first;
            var statusHint = statusData.second;            

            var result = new List<Label>();

            Label statusBox = new Label();
            Label infoBox = new Label();
            Label hintBox = new Label();
            Button cancelBox = new Button();
            float infoCancelRatio = 0.9F;

            infoBox.Width = (int)(cellWidth * infoCancelRatio);
            infoBox.TextAlign = ContentAlignment.MiddleCenter;
            // infoBox.Height = (cellHeight+1) / 2;
            infoBox.Text = information;
            infoBox.Location = new Point(begX, begY);
            infoBox.BorderStyle = BorderStyle.FixedSingle;
            infoBox.Name = controlItemNamePrefix + "infoBox_" + information;

            statusBox.Width = cellWidth;
            statusBox.Height = (cellHeight+1) / 2;
            statusBox.BackColor = backColor;
            statusBox.Location = new System.Drawing.Point(begX, begY + infoBox.Height);
            statusBox.BorderStyle = BorderStyle.FixedSingle;
            statusBox.Name = controlItemNamePrefix + "statusBox_" + information;

            cancelBox.Width = (int)(cellWidth * (1 - infoCancelRatio));
            cancelBox.TextAlign = ContentAlignment.MiddleCenter;
            cancelBox.Height = infoBox.Height;
            cancelBox.Location = new System.Drawing.Point(begX + (int)(cellWidth * infoCancelRatio), begY);
            cancelBox.Image = global::myBestShop.Properties.Resources.cancel;
            cancelBox.Name = controlItemNamePrefix + "cancelBox_" + information;

            hintBox.Width = statusBox.Width;
            hintBox.Height = cancelBox.Height;
            hintBox.TextAlign = ContentAlignment.MiddleCenter;
            hintBox.Location = new Point(begX, begY + statusBox.Height + hintBox.Height);
            hintBox.Text = statusHint;
            hintBox.BorderStyle = BorderStyle.FixedSingle;
            hintBox.Name = controlItemNamePrefix + "hintBox_" + information;

            return new List<Control> { infoBox, hintBox, statusBox, cancelBox };
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
