using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasHarper_Cs_Project.Data
{
    internal class ProductBST
    {
        public Node Root;

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

        public ProductBST()
        {
            //this needs to create list of all tasks
            //then add all items to the bst
            using (var db = new CargoHubEntities())
            {
                var productList = db.CargoHubProducts.ToList();

                foreach (var item in productList)
                {
                    Node nodeBeingAdded = new Node(item.ProductID, item.ProductName, item.ProductCategory, item.ProductQuantity, item.ProductCost, item.ProductReplenishTime);

                    if (this.Root == null)
                    {
                        this.Root = nodeBeingAdded;
                    }
                    else
                    {
                        this.addProductToTree(this.Root, nodeBeingAdded);
                    }
                }

            }
        }



        public void addProductToTree(Node CurrentNode, Node NodeToAdd)
        {
            //checks if the node needs to go to the right of the current node, then checks if the node can be placed the current nodes child
            //need to check if the title is more or less, use the .Compare ting ive learnt
            if (string.Compare(CurrentNode.ProductName, NodeToAdd.ProductName) == -1)
            {
                if (CurrentNode.RightChild == null)
                {
                    //add child to tree
                    CurrentNode.RightChild = NodeToAdd;
                }
                else
                {
                    //recursively call this function
                    addProductToTree(CurrentNode.RightChild, NodeToAdd);
                }
            }

            if (string.Compare(CurrentNode.ProductName, NodeToAdd.ProductName) == 1)
            {
                if (CurrentNode.LeftChild == null)
                {
                    //add child to tree
                    CurrentNode.LeftChild = NodeToAdd;
                }
                else
                {
                    addProductToTree(CurrentNode.LeftChild, NodeToAdd);

                }
            }
        }

        //return the node you are searching for, so that data can be pulled through
        public Node TraverseProductTree(Node CurrentNode, string valueToSearch)
        {

            if (CurrentNode.ProductName == valueToSearch)
            {
                return CurrentNode;
            }


            if (string.Compare(CurrentNode.ProductName, valueToSearch) == -1)
            {
                if (CurrentNode.RightChild == null)
                {
                    return null;
                }

                return TraverseProductTree(CurrentNode.RightChild, valueToSearch);

            }

            if (string.Compare(CurrentNode.ProductName, valueToSearch) == 1)
            {
                if (CurrentNode.LeftChild == null)
                {
                    return null;
                }
                return TraverseProductTree(CurrentNode.LeftChild, valueToSearch);
            }
            return null;
        }

        public void EditTreeItem(Node CurrentNode, string valueToSearch)
        {
            if (CurrentNode.ProductName == valueToSearch)
            {
                //code to edit the tree
            }


            if (string.Compare(CurrentNode.ProductName, valueToSearch) == -1)
            {
                if (CurrentNode.RightChild == null)
                {
                    return;
                }

                EditTreeItem(CurrentNode.RightChild, valueToSearch);

            }

            if (string.Compare(CurrentNode.ProductName, valueToSearch) == 1)
            {
                if (CurrentNode.LeftChild == null)
                {
                    return;
                }
                EditTreeItem(CurrentNode.LeftChild, valueToSearch);
            }
        }
    }
}
