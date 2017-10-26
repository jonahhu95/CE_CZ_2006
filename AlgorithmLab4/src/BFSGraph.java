
import com.sun.rowset.internal.Row;
import java.io.BufferedReader;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.FileReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.LineNumberReader;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import java.util.HashMap;
import java.util.HashSet;
import java.util.Iterator;
import java.util.LinkedHashSet;
import java.util.LinkedList;
import java.util.List;
import java.util.Map;
import java.util.Queue;
import java.util.Random;
import java.util.Scanner;
import java.util.Set;
import java.util.Stack;
import java.util.Vector;
import javax.swing.JFileChooser;
import javax.swing.filechooser.FileNameExtensionFilter;
import jxl.Workbook;
import jxl.write.Label;
import jxl.write.WritableSheet;
import jxl.write.WritableWorkbook;
import org.apache.poi.hpsf.HPSFException;
import org.apache.poi.hssf.usermodel.HSSFCell;
import org.apache.poi.hssf.usermodel.HSSFCellStyle;
import org.apache.poi.hssf.usermodel.HSSFRow;
import org.apache.poi.hssf.usermodel.HSSFSheet;
import org.apache.poi.hssf.usermodel.HSSFWorkbook;

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
/**
 *
 * @author Joey
 */
public class BFSGraph {

    int[][] edge; //used to generate random pairs

    int vertices;
    int edges;
    LinkedList<Integer> adj[]; //Adjacency Lists
    List<int[]> list = new ArrayList<>();
    int count;

    public BFSGraph(int v) {
        this.vertices = v;
        adj = new LinkedList[v + 1];
        for (int i = 0; i < v + 1; ++i) {
            adj[i] = new LinkedList<Integer>();
        }
    }

    // add edge into the graph
    void addEdge(int v, int w) {
        //undirected graph
        adj[v].add(w);
        adj[w].add(v);
    }

    //generate random undirected graph
    void GenerateRandGraphs(int e) {
        this.edges = e;
        this.edge = new int[e + 1][2];
        int i = 0;
        int j;

        try {
            // Build a connection between two random vertex.
            while (i <= e) {
                int num1 = 1 + (int) Math.floor(Math.random() * vertices);
                int num2 = 1 + (int) (Math.random() * vertices);

                //does not contain pairs
                if (!adj[num1].contains(num2) && num1 != num2) {
                    edge[i][0] = num1;
                    edge[i][1] = num2;
                    addEdge(num1, num2);
                    i++;
                }
            }
        } catch (Exception ex) {
            System.out.print(ex.toString());
        }
        // Print the random graph.
        System.out.println("\nThe generated random graph is: ");
        for (i = 0; i < vertices; i++) {
            count = 0;
            System.out.print("\n\t " + (i + 1) + "-> { ");
            for (j = 0; j < e; j++) {
                if (edge[j][0] == i + 1) {
                    System.out.print(edge[j][1] + " ");
                    count++;
                } else if (edge[j][1] == i + 1) {
                    System.out.print(edge[j][0] + " ");
                    count++;
                } else if (j == e - 1 && count == 0) {
                    System.out.print("Isolated Vertex");
                }
            }
            System.out.print(" }");
        }
    }

    int iteration = 0;
    int stopNo = 0;

    public String findPath(int v, int w) {
        this.iteration = 0;
        this.stopNo = 0;
        try {
            Queue<Integer> q = new LinkedList<Integer>(); //create queue
            boolean[] visited = new boolean[vertices + 1];
            String[] pathTo = new String[vertices + 1];
            q.add(v); //add source to queue
            pathTo[v] = v + " "; 
            while (q.peek() != null) {
                if (runBFS(q.poll(), w, visited, q, pathTo)) { 
                    break;
                }
            }

            boolean isPreviousDigit = false;
            for (int i = 0; i < pathTo[w].length(); i++) {
                if (Character.isDigit(pathTo[w].charAt(i))) {
                    if (!isPreviousDigit) {
                        stopNo++;
                        isPreviousDigit = true;
                    }
                } else {
                    isPreviousDigit = false;
                }
            }

            return pathTo[w];
        } catch (Exception ex) {

        }

        return null;

    }

    private boolean runBFS(int v, int w, boolean[] visited, Queue<Integer> q, String[] pathTo) {
        if (visited[v]) {
        } else if (v == w) {
            return true;
        } else {
            //source != destination
            visited[v] = true; //mark as visited
            Iterator<Integer> vi = adj[v].listIterator(); 
            while (vi.hasNext()) {
                int nextVertex = vi.next();
                pathTo[nextVertex] = pathTo[v] + nextVertex + " ";
                iteration++;
                //System.out.println(pathTo[nextVertex]);
                q.add(nextVertex);
            }
        }

        return false;
    }

    public void shuffleNames() {
        getCountryName();
        Collections.shuffle(st);
        //System.out.println(st);
    }

    ArrayList<String> st = new ArrayList<String>();

    public String getNameFromArray(int c) {
        return st.get(c - 1);
    }

    public void getCountryName() {
        String filePath = "C:\\Users\\Joey\\Desktop\\countries.txt";

        try {
            LineNumberReader lineReader = new LineNumberReader(new FileReader(filePath));
            String lineText = null;

            while ((lineText = lineReader.readLine()) != null) {
                int lineNumber = lineReader.getLineNumber();
                //if (lineNumber == c) {
                st.add(lineText);
                //System.out.println(lineReader.getLineNumber() + ": " + lineText);
                //System.out.println(lineNumber + ": " + lineText);
                //return lineText;
                //}
            }
            lineReader.close();

        } catch (IOException ex) {
            System.err.println(ex);
        }

        //return "Out of bounds!";
    }

    static class Computation {

        int stops;
        long computeTime;
        int edgesNoToGoThru;

        public Computation(int s, long c, int e) {
            this.stops = s;
            this.computeTime = c;
            this.edgesNoToGoThru = e;
        }

        public long getTime() {
            return computeTime;
        }

        public int getStops() {
            return stops;
        }

        public int getEdgesNo() {
            return edgesNoToGoThru;
        }

    }

    public static boolean contains(List<Computation> list, int iterations, long t) {
        for (Computation object : list) {
            if (object.getStops() == iterations && object.getTime() > t) {
                return true;
            }
        }
        return false;
    }

    public static void exportToExcel(String sheetName, ArrayList headers,
            ArrayList data, File outputFile) throws HPSFException {
        HSSFWorkbook wb = new HSSFWorkbook();
        HSSFSheet sheet = wb.createSheet(sheetName);

        int rowIdx = 0;
        short cellIdx = 0;

        // Header
        HSSFRow hssfHeader = sheet.createRow(rowIdx);
        HSSFCellStyle cellStyle = wb.createCellStyle();
        cellStyle.setAlignment(HSSFCellStyle.ALIGN_CENTER);
        for (Iterator cells = headers.iterator(); cells.hasNext();) {
            HSSFCell hssfCell = hssfHeader.createCell(cellIdx++);
            hssfCell.setCellStyle(cellStyle);
            hssfCell.setCellValue((String) cells.next());
        }
        // Data
        rowIdx = 1;
        for (Iterator rows = data.iterator(); rows.hasNext();) {
            ArrayList row = (ArrayList) rows.next();
            HSSFRow hssfRow = sheet.createRow(rowIdx++);
            cellIdx = 0;
            for (Iterator cells = row.iterator(); cells.hasNext();) {
                HSSFCell hssfCell = hssfRow.createCell(cellIdx++);
                hssfCell.setCellValue((String) cells.next());
            }
        }

        wb.setSheetName(0, sheetName, HSSFWorkbook.ENCODING_COMPRESSED_UNICODE);
        try {
            FileOutputStream outs = new FileOutputStream(outputFile);
            wb.write(outs);
            outs.close();
        } catch (IOException e) {
            throw new HPSFException(e.getMessage());
        }

    }

    public static void main(String[] args) throws HPSFException {
        long start;
        long stop;
        System.out.println("Total of countries: 196");

        Scanner sc = new Scanner(System.in);
        System.out.println("Please input number of vertices: ");
        int v = sc.nextInt();
        System.out.println("Please input number of edges: ");
        int e = sc.nextInt() - 1;

        //
        BFSGraph g = new BFSGraph(v);
        g.GenerateRandGraphs(e);
        //

        System.out.println(" \n\n");
        System.out.println("************************************************************************************");
        System.out.println("Number of vertices: " + v);
        System.out.println("Number of edges: " + (e + 1));
        System.out.println(" ");
        start = 0;
        stop = 0;
        System.out.print("The shortest path is: ");
        start = System.nanoTime();
        System.out.println(g.findPath(2, 10));
        stop = System.nanoTime();
        System.out.println("Number of stops: " + g.stopNo);
        System.out.println("CPU computation time: " + (stop - start) + " nanoseconds");
        if (g.stopNo == 2) {
            System.out.println("Non-stop flight");
            System.out.println("Departure city: ");
            System.out.println("Arrival city: ");
            System.out.println(" ");
        } else if (g.stopNo > 2) {
            System.out.println("Stops in between cities! \n");
        } else {
            System.out.println("No path!! \n");
        }

        System.out.println("Number of iteration executed to find shortest path: " + g.iteration);
        System.out.println("************************************************************************************");

//        List<Computation> t = new ArrayList<Computation>();
//        int i = 0;
//        for (int k = 1; k <= v; k++) {
//            for (int j = 1; j <= v; j++) {
//
//                start = 0;
//                stop = 0;
//                //System.out.print("The shortest path is: ");
//                start = System.nanoTime();
//                g.findPath(k, j);
//                stop = System.nanoTime();
//                if (contains(t, g.stopNo, (stop - start)) && g.stopNo > 2) {
//                } else {
//                    t.add(new Computation(g.stopNo, (stop - start), g.iteration));
//                }
//            }
//        }
//
//        Collections.sort(t, Comparator.comparing(Computation::getStops).thenComparing(Computation::getTime));
//        File f = new File("C:\\Users\\Joey\\Desktop\\data.xls");
//
//        ArrayList data = new ArrayList();
//        ArrayList headers = new ArrayList();
//
//        headers.add("Queue");
//        headers.add("Cpu time");
//        headers.add("Stops");
//
//        for (Computation elem : t) {
//            ArrayList cells = new ArrayList();
//            cells.add(Integer.toString(elem.getEdgesNo()));
//            cells.add(Long.toString(elem.getTime()));
//            cells.add(Integer.toString(elem.getStops()));
//            data.add(cells);
//        }
//
//        exportToExcel("Test", headers, data, f);
//        for (Computation elem : t) {
//            System.out.println("\nNumber of queue operations done: " + elem.getEdgesNo());
//            System.out.println("CPU computation time: " + elem.getTime() + " nanoseconds");
//            System.out.println("Stops no: " + elem.getStops());
        //System.out.println(elem.getStops() + "  " + elem.getTime() + "\n");
    }

    //adjancey list is used because time complexity is more important
}
