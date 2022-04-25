namespace Savas.Revision.DataStructures;

using Xunit;

/// LRU Cache data structure

class LruCacheItem<K, V>
{

    public K Key { get; set; }
    public V? Value { get; set; }
}

class LruCache<K, V>
{
    private int capacity;
    private Dictionary<K, LinkedListNode<LruCacheItem<K, V>>> cache = new Dictionary<K, LinkedListNode<LruCacheItem<K, V>>>();
    private LinkedList<LruCacheItem<K, V>> lru = new LinkedList<LruCacheItem<K, V>>();

    public LruCache(int capacity)
    {
        this.capacity = capacity;
    }

    public bool ContainsKey(K key) => this.cache.ContainsKey(key);

    public V Get(K key)
    {
        var node = this.cache[key];
        this.lru.Remove(node);
        this.lru.AddLast(node);

        return node.Value.Value;
    }

    public void Put(K key, V val)
    {
        if (this.cache.ContainsKey(key))
        {
            var node = this.cache[key];
            node.Value.Value = val;
            this.lru.Remove(node);
            this.lru.AddLast(node);
        }
        else
        {
            var node = new LinkedListNode<LruCacheItem<K, V>>(new LruCacheItem<K, V> { Key = key, Value = val });
            if (this.cache.Count == capacity)
            {
                // Remove the first entry to make space
                var removed = this.lru.First.Value;
                this.lru.RemoveFirst();
                this.cache.Remove(removed.Key);
            }
            // Add new entry
            this.cache.Add(key, node);
            this.lru.AddLast(node);
        }
    }
}

/// --- Test infrastructure and test cases

public class RluCacheTests
{
    public static List<object[]> Data => new List<object[]>
    {
        new object[] {
            2,
            new (int, int?)[] { (1, 1), (2, 2), (1, null), (3, 3), (2, null), (4, 4), (1, null), (3, null), (4, null) },
            new int?[] { null, null, 1, null, -1, null, -1, 3, 4 }
        },
        new object[] {
            2,
            new (int, int?)[] { (2, 1), (2, 2), (2, null), (1, 1), (4, 1), (2, null) },
            new int?[] { null, null, 2, null, null, -1 }
        }
    };

    [Theory]
    [MemberData(nameof(RluCacheTests.Data))]
    public void RluCacheTest(int capacity, (int, int?)[] operations, int?[] expected)
    {
        int?[] output = new int?[operations.Length];

        var cache = new LruCache<int, int>(capacity);

        for (int i = 0; i < operations.Length; i++)
        {
            var op = operations[i];
            if (op.Item2 == null)
            {
                output[i] = cache.ContainsKey(op.Item1) ? cache.Get(op.Item1) : -1;
            }
            else
            {
                output[i] = null;
                cache.Put(op.Item1, op.Item2.Value);
            }
        }

        Assert.True(output.SequenceEqual(expected));
    }
}