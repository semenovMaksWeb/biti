package untitled.src.main.java.org.example;

import java.util.Scanner;
import java.util.Random;
public class Main
{
    public static void main(String[] args) {
        Scanner in = new Scanner(System.in);
        System.out.println("Введите число в диапозоне от 3 до 15");
        int count = in.nextInt();
        passwordGenerator(count, "GShQVvZSLgigZR7PdRKw");
    }
    public static void passwordGenerator(int count, String charList){
        StringBuilder password = new StringBuilder();
        if(count < 3) { count = 3; }
        if(count > 15) { count = 15; }
        for (int i = 1; i <= count; i++ ) {
            Random rand = new Random();
            int indexChar = rand.nextInt(charList.length() - 1);
            password.append(charList.charAt(indexChar));
        }
        System.out.print(password);
    }
}