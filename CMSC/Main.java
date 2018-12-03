import java.io.IOException;
import java.util.List;

public class Main {

    public static void main(String[] args) {
        CoursesApi api = new CoursesApi();

        try {
            List<Course> courses = api.getAllCourses();

            for (Course c : courses) {
                System.out.println(c.getTitle());
            }
        }
        catch (IOException ex){
            System.out.println("error");
        }
    }
}
