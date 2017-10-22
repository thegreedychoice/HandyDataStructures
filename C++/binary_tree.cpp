#include <iostream>
#include <chrono>
#include <thread>

using namespace std;

struct node{
    int data;
    struct node* left;
    struct node* right;
};

struct node* newNode(int value)
{
    struct node* node = new(struct node);
    node->data = value;
    node->left = NULL;
    node->right = NULL;

    return(node);
};

static int lookup(struct node* node, int target)
{
    if (node == NULL) {
        return(false);
    }
    else{
        if (node->data == target)
        {
            return(true);
        }
        else{
            if (node->data > target)
                return(lookup(node->left, target));

            else
                return(lookup(node->right, target));
        }
    }

}

static struct node* insert(struct node* node, int value)
{
if(node == NULL){
    return(newNode(value));
}
else{
    if(node->data > value)
        node->left = insert(node->left, value);
    else
        node->right = insert(node->right, value);

    return(node);
}
}

static int count(struct node* node)
{
    if(node == NULL)
        return(0);
    else
        return(count(node->left) + 1 + count(node->right));
}

static int maxDepth(struct node* root)
{   // calculate the max of left and rightsubtree at each node and
    if(root == NULL)
        return(0);
    int left_subtree_depth = maxDepth(root->left);
    int right_subtree_depth = maxDepth(root->right);

    if(left_subtree_depth > right_subtree_depth)
        return(left_subtree_depth+1);
    else
        return(right_subtree_depth+1);
}

static int minValue(struct node* root)
{
    if(root == NULL){
        return INT_MAX;
    }
    else{
        struct node* node = root;
        while(node->left != NULL)
            node = node->left;

        return(node->data);
    }
}

static int maxValue(struct node* root)
{
    if(root == NULL){
        return INT_MIN;
    }
    else{
        struct node* node = root;
        while(node->right != NULL)
            node = node->right;

        return(node->data);
    }
}

static void traverse_inorder(struct node* node)
{
   if(node == NULL)
        return;
   else{
        traverse_inorder(node->left);
        cout << node->data << " ";
        traverse_inorder(node->right);
   }
}

static void traverse_postorder(struct node* node)
{
   if(node == NULL)
        return;
   else{
        traverse_postorder(node->left);
        traverse_postorder(node->right);
        cout << node->data << " ";
   }
}

static int has_pathsum(struct node* node, int sum)
{
    if(node == NULL){
        return (sum == 0);
    }
    else{
        int new_sum = sum - node->data;
        return(has_pathsum(node->left, new_sum) ||
        has_pathsum(node->right, new_sum));
    }
}

static int pathsum(struct node* root, struct node* node, int sum)
{
    if(node == NULL){
        return(sum == 0);
    }
    else{
        int newSum = sum - node->data;
        int l = pathsum(root, node->left, newSum);
        int r = pathsum(root, node->right, newSum);

        int res = l || r;
        if(res)
            if node
            cout << node->data << " ";


        return res;
    }
}

int main()
{

struct node* root = NULL;

root = insert(root, 5);
root = insert(root, 7);
root = insert(root, 6);
root = insert(root, 3);
root = insert(root, 4);
root = insert(root, 2);
root = insert(root, -1);
root = insert(root, 0);
root = insert(root, 1);

int option;

while(1){
    cout<<endl;
    cout << "Binary Tree operations - " <<endl;
    cout << "1. Insert value - " <<endl;
    cout << "2. Search value - " <<endl;
    cout << "3. Count Nodes - " <<endl;
    cout << "4. Max Depth - " <<endl;
    cout << "5. Min Value - " <<endl;
    cout << "6. Max Value - " <<endl;
    cout << "7. Inorder traversal" <<endl;
    cout << "8. Postorder traversal" <<endl;
    cout << "9. Has Path Sum?" <<endl;
    cout << "0. Exit - " <<endl;
    cin >> option;

    if(option == 1){
        cout << "Enter value : ";
        int val;
        cin >> val;
        root = insert(root, val);
        if(root != NULL)
            cout << "Inserted Value : " << val;
        else
            cout << "Insertion Error!";
    }
    else if(option == 2){
        cout << "Enter value : ";
        int val;
        cin >> val;
        if(lookup(root, val))
            cout << "Value : " << val << " Present in Tree";
        else
            cout << "Value Not Present!";
    }
    else if(option == 3){
        cout << "No. of Nodes in the Tree : " << count(root);

    }
    else if(option == 4){
        cout << "Max Depth : " << maxDepth(root);
    }
    else if(option == 5){
        int min_v = minValue(root);
        if(min_v != INT_MAX)
            cout << "Min Value : " << min_v << endl;
        else
            cout << "Empty Tree";
    }
    else if(option == 6){
        int max_v = maxValue(root);
        if(max_v != INT_MIN)
            cout << "Max Value : " << max_v << endl;
        else
            cout << "Empty Tree";
    }
    else if(option == 7){
        cout << "Inorder traversal : " << endl;
        traverse_inorder(root);
    }
    else if(option == 8){
        cout << "Postorder traversal : " << endl;
        traverse_postorder(root);
    }
    else if(option == 9){
        cout << "Enter the Path Sum to check : ";
        int sum;
        cin >> sum;
        if(pathsum(root, sum))
        {
            cout << endl;
            cout << "Path-Sum found!" <<endl;
        }

        else
            cout << "No paths for the sum!" << endl;
    }
    else{
        return 0;
    }

    cout << endl;
    std::this_thread::sleep_for(std::chrono::milliseconds(500));
}
return 1;
}
