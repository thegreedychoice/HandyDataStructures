
class Graph(object):
	"""This class is an implementation of an undirected Graph with all the necessary associated operations."""
	def __init__(self, graph_dict=None):
		super(Graph, self).__init__()
		if graph_dict == None:
			self.g = self.__initialize_graph()
		else:
			self.g = graph_dict



	def __initialize_graph(self):
		graph = dict()
		print "Enter the Number of Nodes : "
		n = int(raw_input
			().strip())
		for i in xrange(n):
			print "Enter the name of Vertex : {}".format(i+1)
			node = raw_input().strip()
			print "Enter the neighbours of Vertex : {} | Format--> a b c (where a b c are neighbours)".format(node) 
			neighbours = raw_input().split()
			print(len(neighbours))
			graph[node] = neighbours
		return graph

	def __generate_edges(self):
		"""
		A static method to generate all the edges in the graph.
		"""
		edges = []
		for vertex in self.g:
			for neighbour in self.g[vertex]:
				if {neighbour, vertex} not in edges:
					edges.append({vertex, neighbour})
		return edges	

	def vertices(self):
		"""
		Returns a list of vertices in the graph.
		"""
		return list(self.g.keys())

	def edges(self):
		"""
		Returns a list of unique edges in the graph
		"""
		return self.__generate_edges()

	def add_vertex(self, vertex):
		"""
		Adds a new vertex with an empty list of neighbours to the Graph if there doesn't exists with the same name or else
		does nothing.
		"""
		if vertex not in self.g:
			self.g[vertex] = []
		print "Added Vertex : {}".format(vertex)

	def add_edge(self, edge):
		"""
		Accepts an edge as a set, tuple or a list and adds the neighbour and vertex accordingly 
		if present or otherwise
		"""
		edge = set(edge)
		(vertex, neighbor) = tuple(edge)
		if vertex not in self.g:
			self.g[vertex] = [neighbor]
		else:
			self.g[vertex].append(neighbor)
		print "Added Edge : {}".format(edge)

	def find_path(self, start_vertx, end_vertx, path=None):
		"""
		Returns the path from start vertex to end vertex.
		"""
		if path is None:
			path = []

		graph = self.g
		path += [start_vertx]
		
		if start_vertx == end_vertx:
			print "Same"
			return path
		if start_vertx not in graph:
			print "Not in Graph"
			return None

		for vertex in graph[start_vertx]:
			if vertex not in path:
				extended_path = self.find_path(vertex, end_vertx, path)

				if extended_path:
					return extended_path

		return None

	def find_all_paths(self, start_vertx, end_vertx, path=[]):
		"""
		FInds all the paths from start vertex to the end vertex
		"""

		graph = self.g
		path += [start_vertx]

		if start_vertx == end_vertx:
			print "Same"
			return [path]
		if start_vertx not in graph:
			print "Not in Graph"
			return []
		paths = []
		for vertex in graph[start_vertx]:
			if vertex not in path:
				extended_paths = self.find_all_paths(vertex, end_vertx, path)

				for p in extended_paths:
					paths.append(p)

		return paths










if __name__ == "__main__":

	gr_dict = {
		"a" : ["d", "f"],
		"b" : ["c"],
		"c" : ["b", "c", "d", "e"],
		"d" : ["a", "c"],
		"e" : ["c"],
		"f" : ["d"]
		}

	g = Graph(gr_dict)
	print g.edges()
	print g.vertices()

	"""
	g.add_vertex("z")
	print g.vertices()

	
	g.add_edge({"a","z"})
	print g.edges()

	g.add_edge({"x","y"})
	print g.vertices()
	print g.edges()
	"""


	print "The path from vertex 'a' to 'b' :"
	print g.find_all_paths("a", "b")


	print "The path from vertex 'a' to 'f' :"
	print g.find_all_paths("a", "f")

	print "The path from vertex 'c' to 'c' :"
	print g.find_all_paths("c", "c")



