using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductAndInventory;

namespace ProductInventoryProject.Model
{
    // The main class that can describe any kind of collection and 
    // implements methods for adding and removing elements of the collection.
    class MyModel<TSours>
    {
        public List<TSours> Products { get; set; }

        public TSours this[int index]
        {
            get => Products[index];
            
            set => Products[index] = value;
        }

        // When creating an instance of the class, a collection of
        // the required type will be automatically created.
        public MyModel()
        {
            Products = new List<TSours>();
        }

        /// <summary>
        /// Adding a new item to the collection.
        /// </summary>
        /// <param name="sours"></param>
        #region Add element
        public void Add(TSours sours)
        {
            Products.Add(sours);
        }
        #endregion

        /// <summary>
        /// Removing an item from the collection by its index.
        /// </summary>
        /// <param name="index"></param>
        #region Delete element
        public void Delete(int index)
        {
            Products.Remove(Products[index]);
        }
        #endregion
    }
}
