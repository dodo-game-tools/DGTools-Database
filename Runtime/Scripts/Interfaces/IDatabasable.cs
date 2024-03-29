﻿namespace DGTools.Database {
    /// <summary>
    /// Implement this interface to allow an object to be stored in <see cref="Database"/>
    /// </summary>
    public interface IDatabasable
    {
        /// <summary>
        /// ID has to  be implemented as <code>int ID { get; set; }</code> 
        /// </summary>
        [DatabaseField] int ID { get; set; }
    }

    public static class IDatabasableExtensions
    {
        /// <summary>
        /// Returns the <see cref="Table"/> of type <typeparamref name="Titem"/>
        /// </summary>
        /// <typeparam name="Titem">Type of an item that implements <see cref="IDatabasable"/></typeparam>
        /// <returns></returns>
        public static Table<Titem> GetTable<Titem>(this Titem item) where Titem : IDatabasable, new()
        {
            return Database.active.GetTable<Titem>();
        }

        /// <summary>
        /// Saves the item in the database
        /// </summary>
        /// <typeparam name="Titem">Type of an item that implements <see cref="IDatabasable"/></typeparam>
        public static void Save<Titem>(this Titem item, bool saveTable = true) where Titem : IDatabasable, new()
        {
            GetTable(item).SaveItem(item);
            if(saveTable)
                GetTable(item).SaveTable();
        }
    }
}
