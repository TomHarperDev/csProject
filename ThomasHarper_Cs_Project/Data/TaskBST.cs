using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Linq;

namespace ThomasHarper_Cs_Project.Data
{
    internal class TaskBST
    {
        public Node Root;

        public class Node
        {
            public int Id;
            public string TaskTitle;
            public string TaskDescription;
            public string TaskAssignedTo;
            public string TaskAssignedBy;

            public Node LeftChild;
            public Node RightChild;


            public Node(int ID, string tasktitle, string taskdescription, string taskassignedto, string taskassignedby)
            {
                this.Id = ID;
                this.TaskTitle = tasktitle;
                this.TaskDescription = taskdescription;
                this.TaskAssignedTo = taskassignedto;
                this.TaskAssignedBy = taskassignedby;

                this.LeftChild = null;
                this.RightChild = null;
            }
        }

        public TaskBST() 
        {
            //this needs to create list of all tasks
            //then add all items to the bst
            //using (var db = new CargoHubEntities())
            //{
            //    var taskList = db.CargoHubEmployeeTasks.ToList();

            //    foreach (var item in taskList)
            //    {
            //        Node nodeBeingAdded = new Node(item.TaskID, item.TaskTitle, item.TaskDescription,item.TaskAssignedTo, item.TaskAssignedBy);

            //        if (this.Root == null)
            //        {
            //            this.Root = nodeBeingAdded;
            //        }
            //        else
            //        {
            //            this.addTaskToTree(this.Root, nodeBeingAdded);
            //        }
            //    }
                
            //}
        }



        public void addTaskToTree(Node CurrentNode, Node NodeToAdd)
        {
            //checks if the node needs to go to the right of the current node, then checks if the node can be placed the current nodes child
            if (string.Compare(CurrentNode.TaskTitle, NodeToAdd.TaskTitle) == -1)
            {
                if (CurrentNode.RightChild == null)
                {
                    //add child to tree
                    CurrentNode.RightChild = NodeToAdd;
                }
                else
                {
                    //recursively call this function
                    addTaskToTree(CurrentNode.RightChild, NodeToAdd);
                }
            }

            if (string.Compare(CurrentNode.TaskTitle, NodeToAdd.TaskTitle) == 1)
            {
                if (CurrentNode.LeftChild == null)
                {
                    //add child to tree
                    CurrentNode.LeftChild = NodeToAdd;
                }
                else
                {
                    addTaskToTree(CurrentNode.LeftChild, NodeToAdd);

                }
            }
        }

        //return the node you are searching for, so that data can be pulled through
        public Node TraverseTaskTree(Node CurrentNode, string valueToSearch)
        {

            if (CurrentNode.TaskTitle == valueToSearch)
            {
                return CurrentNode;
            }


            if (string.Compare(CurrentNode.TaskTitle, valueToSearch) == -1)
            {
                if (CurrentNode.RightChild == null)
                {
                    return null;
                }

                return TraverseTaskTree(CurrentNode.RightChild, valueToSearch);

            }

            if (string.Compare(CurrentNode.TaskTitle, valueToSearch) == 1)
            {
                if (CurrentNode.LeftChild == null)
                {
                    return null;
                }
                return TraverseTaskTree(CurrentNode.LeftChild, valueToSearch);
            }
            return null;
        }
    }
}
