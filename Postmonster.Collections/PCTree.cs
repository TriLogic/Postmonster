using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Postmonster.Collections
{
    public static class PCTree
    {
        public static void Link(IPCItem item, IPCItem? parent = null)
        {
            item.Parent = parent;

            PCItem? prev = null;
            if (item.Items != null && item.Items.Count > 0)
            {
                item.Items.ForEach(child => {

                    // set the child's prev to prev
                    child.Prev = prev;

                    // set the prev's next to child
                    if (prev != null)
                        prev.Next = child;

                    // set prev to current child
                    prev = child;

                    // link the child
                    Link(child, item);
                });
            }
        }

        public static IPCItem GetRoot(IPCItem item)
        {
            while (item.Parent != null)
                item = item.Parent;
            return item;
        }


        // Traditional Postman depth first search for a named item
        public static PCItem? SearchDeep(string name, IPCItem node, bool global = true)
        {
            // If this is a global search 
            if (global)
            {
                node = GetRoot(node);
            }

            // Check the 'incoming node' first
            if (node.Parent != null)
            {
                // root node is not a candiate
                if (string.Compare(node.Name, name, true) == 0)
                    return node as PCItem;
            }

            // DFS search each child node
            if (node.Items != null && node.Items.Count > 0)
            {
                // DFS the child items
                foreach (var item in node.Items)
                {
                    var found = SearchDeep(name, item, false);
                    if (found != null)
                        return found;
                }
            }

            // Not Here
            return null;
        }

        public static PCItem? SearchWide(string name, IPCItem node, bool global = true)
        {
            // 1) Search this node,
            // 2) search every child node
            // 3) search children of children

            Queue<IPCItem> queue = new();

            if (global)
            {
                node = GetRoot(node);
            }

            queue.Enqueue(node);
            while (queue.Count > 0)
            {
                // Check the next node
                IPCItem item = queue.Dequeue();

                // The root node is not a canidate
                if (item.Parent != null)
                {
                    if (string.Compare(node.Name, name, true) == 0)
                    {
                        queue.Clear();
                        return item as PCItem;
                    }
                }

                // Enqueue the child nodes to be searched later
                if (item.HasChildren())
                {
                    foreach (var child in item.Items)
                        queue.Enqueue(child);
                }
            }

            queue.Clear();
            return null;
        }

        public static PCItem? SearchHome(string name, IPCItem node, bool global = false)
        {
            // 1) search node
            // 2) search prev siblings
            // 3) search next siblings
            // 4) search parent

            // root is not a candiate
            if (node.Parent == null)
                return null;

            // search node
            if (string.Compare(node.Name, name, true) == 0)
                return node as PCItem;

            // Search prev siblings
            IPCItem item = node.Prev;
            while(item != null)
            {
                if (string.Compare(item.Name, name, true) == 0)
                    return node as PCItem;
                item = node.Prev;
            }

            // Search next siblings
            item = node.Next;
            while (item != null)
            {
                if (string.Compare(item.Name, name, true) == 0)
                    return node as PCItem;
                item = node.Next;
            }

            // Search parent
            item = node.Parent;
            if (item.Parent != null && string.Compare(item.Name, name, true) == 0)
                return item as PCItem;

            // Some items will be searched twice - collections are not that large.
            return global ? SearchDeep(name, node, true) : null;
        }

    }
}
