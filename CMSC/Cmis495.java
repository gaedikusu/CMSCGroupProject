package project495;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.PrintWriter;
import java.text.ParseException;
import java.util.Scanner;
import java.util.logging.Level;
import java.util.logging.Logger;

import org.json.simple.JSONArray;
import org.json.simple.JSONObject;
import org.json.simple.parser.JSONParser;

public class json495 {
	

	public static void main(String[] args) {
		
		Scanner scan1 =new Scanner(System.in);
		
		System.out.println("please enter your first name");
		String firstName = scan1.nextLine();
		
		System.out.println("please enter your last name");
		String lastName = scan1.nextLine();
		
		// creating new Json Object 
				JSONObject root =new JSONObject();
				
				root.put("firstName", firstName);
				root.put("lastName", lastName);
				
				JSONArray courses =new JSONArray();
		
		while(true) {
			// course name
			System.out.println("please enter your course name");
			String courseName = scan1.nextLine();

			// check
			if(courseName.length()==0) {
				break;
			}
			
			// course ID
			System.out.println("please enter your course ID");
			int courseID = scan1.nextInt();
			
			if(scan1.hasNextLine()) { 
				scan1.nextLine();
				
			}
			
			JSONObject courseObject= new JSONObject();
			courseObject.put("courseName", courseName);
			courseObject.put("courseId", courseID);
			
			// add course to the array
			courses.add(courseObject);
			
		}
		
		
		
		// add array to the root object
		root.put("courses", courses);
		
		
		System.out.println(root.toJSONString());
	
		
		File file = new File("StudentsClasses.txt");
		try (PrintWriter writer = new PrintWriter(file)){
			writer.print(root.toJSONString());
		} catch (FileNotFoundException ex) {
			System.out.println(ex.toString());
			
		}
		
		System.out.println("FIle created succesfully\n\n hit Return to display");
		scan1.nextLine();
		
		
		try {
			scan1 = new Scanner(file);
			
			StringBuilder jsonIn = new StringBuilder();
			while(scan1.hasNextLine()) {
				jsonIn.append(scan1.nextLine());
			}
			System.out.println(jsonIn.toString());
			
		
		
		
		JSONParser parser =new JSONParser();
		
			
			JSONObject objroot = (JSONObject) parser.parse(jsonIn.toString());
			
			System.out.printf("Student name is %s\n", objroot.get("name").toString());
			
		JSONArray coursesIn = (JSONArray) objroot.get("courses");
		
		for (int i=0; 1< coursesIn.size();i++) {
			JSONObject courseIn = (JSONObject) coursesIn.get(i);
			long IDIn =(long) courseIn.get("classID");
			String courseNameIn = (String) courseIn.get("courseName");
			System.out.printf("Course%s; ID %d\n", IDIn, courseNameIn);
		}	
		
		}catch (FileNotFoundException ex) {
				System.out.println(ex.toString());
} catch (ParseException ex) {
				System.out.println(ex.toString());
			}
	
		}
}
