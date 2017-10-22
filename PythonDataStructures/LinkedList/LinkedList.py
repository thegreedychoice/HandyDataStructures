from __future__ import print_function


class Node :
    '''Node class holds information stored by each node'''
    def __init__(self, data):
        self.data = data
        self.next = None


class LinkedList :
    '''Linked List class stores the linked list and perform a set of operations on the list'''
    def __init__(self):
        self.head = None

    def insert(self, value):
        newNode = Node(value)

        if self.head == None:
            self.head = newNode

        else:
            newNode.next = self.head
            self.head = newNode

    def printList(self, list=None) :
        if list == None:
            temp = self.head
        else:
            temp = list

        while temp != None:
            print(temp.data, end=' --> ')
            temp = temp.next

        print (None)

    def delete(self, value):
        curr = self.head
        prev = None
        temp = None
        isPresent = False

        if curr.data == value:
            temp = curr
            curr = curr.next
            self.head = curr
            isPresent = True

        else :

            while curr != None:
                if curr.data == value:
                    temp = curr
                    prev.next = curr.next
                    isPresent = True

                prev = curr
                curr = curr.next

        if isPresent:
            print("Deleted ", temp.data)
            del temp


    def reverse(self):
        prev = None
        curr = self.head
        next = None

        while curr != None:
            next = curr.next
            curr.next = prev
            prev = curr
            curr = next


        self.head = prev
        self.printList()



    def search(self, key):
        if self.head == None:
            return

        found = False
        temp = self.head
        while temp != None:
            if temp.data == key:
                found = True

            temp = temp.next

        if found == True:
            print("Key Present!")
        else:
            print ("Key not Present!")


if __name__ == "__main__":
    list = LinkedList()

    while True:
        operation = raw_input("Linked List Operations :\n1.Insert\n2.Search\n3.Delete\n4.Reverse\n5.Print List\n")
        if operation == "1":
            newItem = raw_input("Enter the value to be inserted!\n")
            list.insert(newItem)
        elif operation == "2":
            newItem = raw_input("Enter the value to be Searched!\n")
            list.search(newItem)
        elif operation == "3":
            newItem = raw_input("Enter the value to be Deleted!\n")
            list.delete(newItem)
        elif operation == "4":
            list.reverse()

        elif operation == "5":
            list.printList()
        else:
            quit()













