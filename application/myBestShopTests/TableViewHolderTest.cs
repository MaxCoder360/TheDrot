using Microsoft.VisualStudio.TestTools.UnitTesting;
using myBestShop.Presentation.Common;
using myBestShop.Utils;
using System.Collections.Generic;

namespace myBestShopTests
{
    [TestClass]
    public class TableViewHolderTest
    {
        [TestMethod]
        public void TableViewHolder_GeneratedCellsCount_Check()
        {
            TableViewHolder viewHolder = new TableViewHolder(400, 400, 0, 0);
            var cells = viewHolder.appendCellRange(10).getReducedCells();
            Assert.AreEqual(10, cells.Count);

            cells = viewHolder.clear().appendCellRange(100).getReducedCells();
            Assert.AreEqual(100, cells.Count);

            List<ComputerWrapper> computers = new List<ComputerWrapper>();
            for (int i = 0; i < 20; i++)
            {
                var computer = new ComputerWrapper(5, ComputerStatus.IS_USED);
                computers.Add(computer);
            }
            cells = viewHolder.clear().appendCellsWithStatuses(computers).getReducedCells();
            Assert.AreEqual(20, cells.Count);
        }

        [TestMethod]
        public void TableViewHolder_GeneratedCellsAttributes_Check()
        {
            TableViewHolder viewHolder = new TableViewHolder(400, 400, 0, 0);
            viewHolder.changeColumnCount(4);
            var cells = viewHolder.appendCellRange(10).getReducedCells();
            foreach (var cell in cells)
            {
                Assert.AreEqual(100, cell.Width);
            }

            TableViewHolder viewHolder1 = new TableViewHolder(100, 100, 0, 0);
            var cells1 = viewHolder1.changeColumnCount(5).appendCellRange(10).getReducedCells();
            foreach (var cell in cells1)
            {
                Assert.AreEqual(100, cell.Width);
                Assert.IsNotNull(cell);
            }
        }

        [TestMethod]
        public void TableViewHolder_allCellsGenerated_Check()
        {
            TableViewHolder holder = new TableViewHolder(300, 300, 0, 0);
            List<ComputerWrapper> computers = new List<ComputerWrapper>();
            for (int i = 0; i < 20; i++)
            {
                var computer = new ComputerWrapper(5, ComputerStatus.IS_USED);
                computers.Add(computer);
            }
            var cells = holder.clear().appendCellsWithStatuses(computers).getCells();

            var statusCount = 0;
            var infoCount = 0;
            var hintCount = 0;
            var cancelCount = 0;
            var otherCount = 0;
            foreach (var cell in cells)
            {
                var splittedCellName = cell.Name.Split("_");
               
                if (splittedCellName[2] == TableViewHolder.statusItemNamePrefix.Split("_")[2])
                {
                    statusCount++;
                } else if (splittedCellName[2] == TableViewHolder.infoItemNamePrefix.Split("_")[2])
                {
                    infoCount++;
                } else if (splittedCellName[2] == TableViewHolder.hintItemNamePrefix.Split("_")[2])
                {
                    hintCount++;
                } else if (splittedCellName[2] == TableViewHolder.cancelItemNamePrefix.Split("_")[2])
                {
                    cancelCount++;
                } else
                {
                    Logger.println("_" + splittedCellName[2] + "_");
                    Logger.println("_" + TableViewHolder.infoItemNamePrefix.Split("_")[2] + "_");
                    Logger.println("_" + TableViewHolder.hintItemNamePrefix.Split("_")[2] + "_");
                    Logger.println("_" + TableViewHolder.cancelItemNamePrefix.Split("_")[2] + "_");
                    Logger.println("_" + TableViewHolder.statusItemNamePrefix.Split("_")[2] + "_");
                    otherCount++;
                }
            }

            Assert.AreEqual(0, otherCount);
            Assert.AreEqual(0, cells.Count % 4);
            Assert.AreEqual(cells.Count / 4, infoCount);
            Assert.AreEqual(cells.Count / 4, statusCount);
            Assert.AreEqual(cells.Count / 4, cancelCount);
            Assert.AreEqual(cells.Count / 4, hintCount);
        }
    }
}