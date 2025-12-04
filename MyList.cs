namespace MyCollections
{
    public class MyList<T>
    {
        private T[] _data;
        private int _size;
        private const int defaultCapacity = 4;
        public int Count => _size;
        public int Capacity => _data.Length;

        //конструктор
        public MyList(int capacity = defaultCapacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));
            _data = new T[capacity];
            _size = 0;
        }

        //indexer
        public T this[int index]
        {
            get
            {
                CheckIndexForAccess(index);
                return _data[index];
            }
            set
            {
                CheckIndexForAccess(index);
                _data[index] = value;
            }
        }

        //resizes array
        private void Grow()
        {
            int NewCapacity;
            if (_data.Length == 0)
            {
               NewCapacity  = defaultCapacity;
            } else
            {
               NewCapacity = _data.Length * 2;
            }
            T[] newArray = new T[NewCapacity];

            Array.Copy(_data, newArray, _size);
            _data = newArray;
        }

        //checks index for access
        private void CheckIndexForAccess(int index)
        {
            if (index < 0 || index >= _size)
                throw new IndexOutOfRangeException("Индекс выходит за пределы массива");
        }

        //Добавление элемента
        public void Add(T item)
        {
            if (_size == _data.Length) Grow();
            _data[_size] = item;
            _size++;
        }

        //removes item at index
        public void RemoveAt(int index)
        {
            CheckIndexForAccess(index);
            for (int i = index; i < _size - 1; i++)
            {
                _data[i] = _data[i + 1];
            }
            _size--;
        }

        //removes first item with value
        public void Remove(T item)
        {
            for (int i = 0; i < _size; i++)
            {
                if (EqualityComparer<T>.Default.Equals(_data[i], item))
                {
                    RemoveAt(i);
                    return;
                }
            }
        }

        //insert item at index
        public void Insert(int index, T item)
        {
            CheckIndexForAccess(index);
            if (_size == _data.Length) Grow();

            for (int i = _size; i > index; i--)
            {
                _data[i] = _data[i - 1];
            }

            _data[index] = item;
            _size++;
        }

        //clears list
        public void Clear()
        {
            _size = 0;
        }
    }
}
