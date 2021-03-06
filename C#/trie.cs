public class TrieNode{
    public Hashtable map;
    public bool endOfWord;
    public int pref_count;
    public int word_count;
    
    public TrieNode(){
    map = new Hashtable();
    endOfWord = true;
    pref_count = 0; 
    word_count = 0;
    }

}

public class Trie{
    TrieNode root;
    
    public Trie(){
        this.root = new TrieNode();
    }
    
    public void add(string s){
        if(s.Length == 0)  return;
        add(s, 0, this.root);
    }
    
    public void add(string s, int index, TrieNode curr){
       
        int len = s.Length;
        if(index == len) {
            curr.word_count++;
            curr.endOfWord = true;
            return;
        }
        
        char c = s[index];
        TrieNode node;
        
        if(!curr.map.Contains(c)){
            //create a new node
            node = new TrieNode();
            
            //update the hashmap of the current node
            curr.map.Add(c, node);
            curr.endOfWord = false;
        }
        else{
            node = (TrieNode)curr.map[c];
        }
        
        node.pref_count++;
        
        add(s, index+1, node);
    }
    
    public bool isPresent(string s){
        if(s.Length == 0) return false;
        
        return isPresent(s, 0, this.root);
    }
    
    public bool isPresent(string s, int index, TrieNode curr){
        int len = s.Length;
        
        if(index == len) {
        /*            
            if(curr.endOfWord == false)
                Console.WriteLine("Its a Prefix!");
            else
                Console.WriteLine("Its a Complete Word!");
        */
            
            return true;
        }
        
        char c = s[index];
        TrieNode node;
        
        if(curr.map.Contains(c)){
            node = (TrieNode)curr.map[c];
        }
        else{
            return false;
        }
        
        return(isPresent(s, index+1, node));
        
        
    }
    public int findcount_prefix(string s){
        if(s.Length == 0) return 0;
        
        return(findcount_prefix(s, 0, this.root));
    }
               
    public int findcount_prefix(string s, int index, TrieNode curr){
        if(s.Length == index){
            return curr.pref_count;
        }
        TrieNode node;
        char c = s[index];
        if(!curr.map.Contains(c)){
            //doesn't contain the character c
            return 0;
        }
        
        node = (TrieNode)curr.map[c]; 
        return(findcount_prefix(s, index+1, node));
        
    }

    
    public int findcount_word(string s){
        if(s.Length == 0) return 0;
        
        return(findcount_word(s, 0, this.root));
    }
    
    public int findcount_word(string s, int index, TrieNode curr){
        if(s.Length == index){
            if(curr.endOfWord == true)
                return curr.word_count;
            else
                return 0;
        }
        
        TrieNode node;
        char c = s[index];
        
        if(!curr.map.Contains(c)){
            //doesn't contain the character c
            return 0;
        }
        
        node = (TrieNode)curr.map[c]; 
        return(findcount_word(s, index+1, node));
        
    }
}