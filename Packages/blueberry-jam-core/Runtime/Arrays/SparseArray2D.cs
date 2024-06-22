using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BJ
{
    public class SparseArray2D<T> : IArray2D<T>
    {
        // TODO serialize
        private Dictionary<Vector2Int, T> data;

        private T defaultValue;

        /**
         * @brief Width is calculated as the difference between the rightmost element ever entered and the leftmost element ever entered.
         *        To change it, call TrimDimensions
         */
        public int Width => highX - lowX;

        /**
         * @brief Height is calculated as the difference between the highest element ever entered and the lowest element ever entered.
         *        To change it, call TrimDimensions
         */
        public int Height => highY - lowY;

        private int lowX = int.MaxValue;
        private int highX = int.MinValue;
        private int lowY = int.MaxValue;
        private int highY = int.MinValue;

        public SparseArray2D()
        {
            this.data = new Dictionary<Vector2Int, T>(25);
            defaultValue = default;
        }

        public SparseArray2D(int width, int height)
        {
            this.data = new Dictionary<Vector2Int, T>(width * height);
            defaultValue = default;
        }

        public SparseArray2D(int width, int height, T defaultValue)
        {
            this.data = new Dictionary<Vector2Int, T>(width * height);
            this.defaultValue = defaultValue;
        }

        public T this[int i]
        {
            get
            {
                Vector2Int coords = Coordinates(i);
                if (data.TryGetValue(coords, out T value))
                {
                    return value;
                }
                else
                {
                    return defaultValue;
                }
            }
            set
            {
                // copied to avoid allocating a Vector2Int
                int x = Mathf.FloorToInt(i / Width);
                int y = i % Height;
                this[x, y] = value;
            }
        }
        private Vector2Int coordsCache;
        public T this[int i, int j]
        {
            get
            {
                if (coordsCache == null)
                {
                    coordsCache = new Vector2Int(i, j);
                }
                coordsCache.x = i;
                coordsCache.y = j;
                if (data.TryGetValue(coordsCache, out T value))
                {
                    return value;
                }
                else
                {
                    return defaultValue;
                }
            }
            set
            {
                if (coordsCache == null)
                {
                    coordsCache = new Vector2Int(i, j);
                }
                coordsCache.x = i;
                coordsCache.y = j;

                data[coordsCache] = value;

                if (i < lowX) lowX = i;
                else if (i > highX) highX = i;

                if (j < lowY) lowY = j;
                else if (j > highY) highY = j;
            }
        }

        public int Count
        {
            get
            {
                return Width * Height;
            }
        }

        public bool IsReadOnly => false;

        // Mirrored from dense implementation
        public Vector2Int Coordinates(int index)
        {
            int x = Mathf.FloorToInt(index / Width);
            int y = index % Height;
            return new Vector2Int(x, y);
        }

        public void Add(KeyValuePair<Vector2Int, T> item)
        {
            this[item.Key.x, item.Key.y] = item.Value;
        }

        public void Clear()
        {
            data.Clear();
        }

        public bool Contains(KeyValuePair<Vector2Int, T> item)
        {
            return data.ContainsKey(item.Key) && data[item.Key].Equals(item.Value);
        }

        // What even uses this?
        public void CopyTo(KeyValuePair<Vector2Int, T>[] array, int arrayIndex)
        {
            int index = 0;
            foreach (KeyValuePair<Vector2Int, T> kvp in data)
            {
                array[index] = kvp;
                index++;
            }
        }

        public IEnumerator<KeyValuePair<Vector2Int, T>> GetEnumerator()
        {
            return data.GetEnumerator();
        }

        public bool Remove(KeyValuePair<Vector2Int, T> item)
        {
            if (data.ContainsKey(item.Key) && data[item.Key].Equals(item.Value))
            {
                data.Remove(item.Key);
                return true;
            }
            else
            {
                return false;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return data.GetEnumerator();
        }

        public void TrimDimensions()
        {
            lowX = int.MaxValue;
            highX = int.MinValue;
            lowY = int.MaxValue;
            highY = int.MinValue;

            foreach (KeyValuePair<Vector2Int, T> kvp in data)
            {
                int x = kvp.Key.x;
                int y = kvp.Key.y;

                if (x < lowX) lowX = x;
                else if (x > highX) highX = x;

                if (y < lowY) lowY = y;
                else if (y > highY) highY = y;
            }
        }
    }
}
