import com.fasterxml.jackson.core.type.TypeReference;
import com.fasterxml.jackson.databind.DeserializationFeature;
import com.fasterxml.jackson.databind.ObjectMapper;

import java.io.IOException;
import java.net.URL;
import java.util.*;

public class CoursesApi {

    private URL COURSES_API, TEXTBOOKS_API, REVIEWS_API, INSTRUCTORS_API;

    private ObjectMapper mapper;

    public CoursesApi() {
        try {
            COURSES_API = new URL("https://umuccoursesapi.azurewebsites.net/api/courses");
            TEXTBOOKS_API = new URL("https://umuccoursesapi.azurewebsites.net/api/textbooks");
            REVIEWS_API = new URL("https://umuccoursesapi.azurewebsites.net/api/reviews");
            INSTRUCTORS_API = new URL("https://umuccoursesapi.azurewebsites.net/api/instructors");
        } catch (IOException ex) {
            // Creating a new URL needs to be in try-catch to avoid an exception.
        }

        // Create a JSON object mapper.
        mapper = new ObjectMapper();
        mapper.configure(DeserializationFeature.FAIL_ON_UNKNOWN_PROPERTIES, false);
    }

    /**
     * Retrieves all courses.
     * @return a list of courses
     * @throws IOException
     */
    public List<Course> getAllCourses() throws IOException {
        return mapper.readValue(COURSES_API, new TypeReference<List<Course>>() {});
    }
}
