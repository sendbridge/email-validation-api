import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;

// create a free acount at https://app.sendbridge.com/signup
// and get your own API key

// more info in integration https://sendbridge.com/email-validation-api

// Please make sure to handle any exceptions appropriately in your production code, 
// such as IOException, MalformedURLException, and ProtocolException. Additionally, 
// you may need to include any necessary libraries or dependencies for making HTTP 
// requests in your Java project, such as Apache HttpClient or OkHttp.

public class JsonHttpGetExample {
    public static void main(String[] args) {
        try {
            // Specify the API endpoint URL
            String apiUrl = "https://api.sendbridge.com/v1/validate/hLxD5h0erBiqmPRbkrjJu4WBdRJI9lMi/tested@emailabc123.com";
            
            // Create a URL object with the API endpoint URL
            URL url = new URL(apiUrl);
            
            // Create a HttpURLConnection object to make the GET request
            HttpURLConnection connection = (HttpURLConnection) url.openConnection();
            connection.setRequestMethod("GET");
            
            // Get the response code from the API
            int responseCode = connection.getResponseCode();
            
            // If the response code indicates a successful request
            if (responseCode == HttpURLConnection.HTTP_OK) {
                // Create a BufferedReader to read the response from the API
                BufferedReader in = new BufferedReader(new InputStreamReader(connection.getInputStream()));
                String inputLine;
                StringBuffer content = new StringBuffer();
                
                // Read the response line by line and append to the content buffer
                while ((inputLine = in.readLine()) != null) {
                    content.append(inputLine);
                }
                in.close();
                
                // Print the JSON response
                System.out.println("JSON response: " + content.toString());
            } else {
                // If the response code indicates an error, print the error message
                System.out.println("Failed to get JSON response. Response code: " + responseCode);
            }
            
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
