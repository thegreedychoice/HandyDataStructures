public class MinHeap{
    public  int capacity;
    public int size;
    private int[] heap;
    public MinHeap(int cap){
        size = 0;
        capacity = cap;
        heap = new int[capacity];
    }
    
    private int getLeftChildIndex(int parentIndex){
        return (parentIndex*2) + 1;
    }
    private int getRightChildIndex(int parentIndex){
        return (parentIndex*2) + 2;
    }
    private int getParentIndex(int childIndex){
        return (childIndex-1)/2;
    }
    
    
    private bool hasLeftChild(int parentIndex){
        return (getLeftChildIndex(parentIndex) < size); 
    }
    private bool hasRightChild(int parentIndex){
        return (getRightChildIndex(parentIndex) < size);
    }
    private bool hasParent(int childIndex){
        return (getParentIndex(childIndex) >= 0);
    }
    
    private int leftChild(int parentIndex){
        return heap[getLeftChildIndex(parentIndex)];
    }
    private int rightChild(int parentIndex){
        return heap[getRightChildIndex(parentIndex)];
    }    
    private int parent(int childIndex){
        return heap[getParentIndex(childIndex)];
    }
    
    private bool hasCapacity(){
        return (size < capacity);
    }
    private bool isEmpty(){
        if(size==0) return true;
        else return false;
    }
    private void swap(int in_a, int in_b){
        int temp = heap[in_a];
        heap[in_a] = heap[in_b];
        heap[in_b] = temp;
    }
    private void heapifyUp(){
        if(isEmpty()) return;
        int index = size-1;
        
        while(hasParent(index) && (parent(index) > heap[index])){
            int parentIndex = getParentIndex(index);
            int temp = heap[parentIndex];
            heap[parentIndex] = heap[index];
            heap[index] = temp;
            
            index = parentIndex;
        }
        
    }
    
    private void heapifyDown(int index){
        //int index = 0;
        
        while(hasLeftChild(index)){
            int smallerChildIndex = getLeftChildIndex(index);
            
            if(hasRightChild(index) && rightChild(index) < leftChild(index))
                smallerChildIndex = getRightChildIndex(index);
            
            if (heap[smallerChildIndex] < heap[index]){
                
                //swap
                swap(smallerChildIndex, index);
                index = smallerChildIndex;
            }
            else
                break;
        }
    }
    
    public int getMinimum(){
        if(isEmpty()) return Int32.MaxValue;
        else
            return heap[0];
        
    }
    
    public int extractMinimum(){
        if(isEmpty()) return Int32.MaxValue;
        else{
            int min = heap[0];
            heap[0] = heap[size-1];
            size--;
            heapifyDown(0);
            return min;
        }
    }
    
    public void Add(int item){
        //ensure capacity
        if(!hasCapacity()) return;
        
        //identify index
        int index = size;
        
        //add item
        heap[index] = item;
        
        //increase size
        size++;
        
        //heapifyup
        heapifyUp();
    }
    
    public int search_index(int item){
        for(int i=0; i<this.size; i++){
            if(heap[i] == item)
                return i;
        }
        
        return Int32.MinValue;
    }
    public void Delete(int item){
        //check if empty
        if(isEmpty()) return;
        
        int index = search_index(item);
        if(index == Int32.MinValue) return;
        
        heap[index] = heap[size-1];
        heap[size-1] = Int32.MaxValue;
        size--;

        heapifyDown(index);
        
    }
    
    public void Print(){
        int min = getMinimum();
        
        if(min == Int32.MaxValue){
            Console.WriteLine("No Min value!");
        }
        else
            Console.WriteLine(min);
    }
    
    
}