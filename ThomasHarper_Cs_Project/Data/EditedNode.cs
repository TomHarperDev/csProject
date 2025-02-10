using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasHarper_Cs_Project.Data
{
    public static class EditedNode
    {
        public class Node
        {
            public int Id;
            public string ProductName;
            public string ProductCategory;
            public int ProductQty;
            public decimal ProductCost;
            public string ProductReplenishTime;

            public Node LeftChild;
            public Node RightChild;


            public Node(int id, string productname, string productcategory, int productqty, decimal productcost, string productreplenishtime)
            {
                this.Id = id;
                this.ProductName = productname;
                this.ProductCategory = productcategory;
                this.ProductQty = productqty;
                this.ProductCost = productcost;
                this.ProductReplenishTime = productreplenishtime;

                this.LeftChild = null;
                this.RightChild = null;
            }
        }
    }
}
