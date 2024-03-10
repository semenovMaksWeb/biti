import java.util.Random;
public class Main
{
    public static void main(String[] args) {
        passwordGenerator(14, "9 GShQVvZSLgigZR7PdRKw");
    }
    public static void passwordGenerator(Integer count, String charList){
        StringBuilder password = new StringBuilder();
        if(count < 3) { count = 3; }
        if(count > 15) { count = 15; }
        for (Integer i = 1; i <= count; i++ ) {
            Random rand = new Random();
            int indexChar = rand.nextInt(charList.length() - 1);
            password.append(charList.charAt(indexChar));
        }
        System.out.print(password.toString());
    }
}
 