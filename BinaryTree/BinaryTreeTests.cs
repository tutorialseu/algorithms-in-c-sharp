namespace Algorithms;


using System;
using FsCheck;
using FsCheck.Xunit;

public class BinaryTreeTests
{
    [Property]
    public Property AddingElementShouldPreserveBinarySearchTreeProperty(int[] values)
    => NodePresevesProperty(CreateTree(values).Root).ToProperty();

    bool NodePresevesProperty<T>(Node<T>? root) where T : IComparable<T>
    => root == null
    || (root.Left == null || root.Left.Value.CompareTo(root.Value) <= 0)
    && (root.Right == null || root.Right.Value.CompareTo(root.Value) >= 0)
    && NodePresevesProperty(root.Left)
    && NodePresevesProperty(root.Right);


    BinaryTree<T> CreateTree<T>(T[] values) where T : IComparable<T>
    {
        var tree = new BinaryTree<T>();
        foreach (var value in values)
            tree.Add(value);

        return tree;
    }

}
