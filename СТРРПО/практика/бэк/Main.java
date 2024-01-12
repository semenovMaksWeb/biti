package org.example;

import com.sun.net.httpserver.HttpServer;

import java.io.*;
import java.net.InetSocketAddress;
import java.nio.charset.StandardCharsets;
import java.sql.SQLException;
import java.util.StringTokenizer;

public class Main {
    public static void main(String[] args) throws IOException {
        int serverPort = 8000;
        HttpServer server = HttpServer.create(new InetSocketAddress(serverPort), 0);
        server.createContext("/api/user", (exchange -> {
            if ("POST".equals(exchange.getRequestMethod())) {
                User user = new User();
                InputStreamReader isr =  new InputStreamReader(exchange.getRequestBody(), StandardCharsets.UTF_8);
                BufferedReader br = new BufferedReader(isr);
                String value = br.readLine();
                StringTokenizer st1 = new StringTokenizer(value, ";");

                while (st1.hasMoreTokens()) {
                    String object = st1.nextToken();
                    String[] element = object.split(":");
                    switch (element[0]){
                        case "name":
                            user.setName(element[1]);
                            break;
                        case "surname":
                            user.setSurname(element[1]);
                            break;
                        case "patronymic":
                            user.setPatronymic(element[1]);
                            break;
                        case "status":
                            user.setStatus(element[1]);
                            break;
                        case "comment":
                            user.setComment(element[1]);
                            break;
                    }
                }
                System.out.println(user.getName());
                System.out.println(user.getSurname());
                System.out.println(user.getPatronymic());
                System.out.println(user.getStatus());
                System.out.println(user.getComment());
                String respText = "Успешно!";
                BD bd = null;
                try {
                    bd = new BD();
                } catch (SQLException e) {
                    System.out.println(e.getLocalizedMessage());
                    throw new RuntimeException(e);
                }
                try {
                    bd.setUser(user);
                } catch (SQLException e) {
                    System.out.println(e.getLocalizedMessage());
                    throw new RuntimeException(e);
                }
                exchange.sendResponseHeaders(200, respText.getBytes().length);
                OutputStream output = exchange.getResponseBody();
                output.write(respText.getBytes());
                output.flush();
                exchange.close();
            }
        }));
        server.setExecutor(null); // creates a default executor
        server.start();
    }
}