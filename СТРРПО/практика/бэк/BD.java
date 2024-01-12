<<<<<<< HEAD
package org.example;

import java.sql.*;

public class BD {
    private final Connection connect;
    public BD() throws SQLException {
        String url = "jdbc:postgresql://localhost/biti?user=postgres&password=1&ssl=false";
        connect = DriverManager.getConnection(url);
        System.out.println("BD start");
    }
    public void setUser(User user) throws SQLException {
        String query = "INSERT INTO public.user (name,surname,patronymic,status,comment) VALUES (?,?,?,?,?)";
        PreparedStatement pst = connect.prepareStatement(query);
        pst.setString(1, user.getName());
        pst.setString(2, user.getSurname());
        pst.setString(3, user.getPatronymic());
        pst.setString(4, user.getStatus());
        pst.setString(5, user.getComment());
        pst.executeUpdate();
    }
}
=======
package org.example;

import java.sql.*;

public class BD {
    private final Connection connect;
    public BD() throws SQLException {
        String url = "jdbc:postgresql://localhost/biti?user=postgres&password=1&ssl=false";
        connect = DriverManager.getConnection(url);
        System.out.println("BD start");
    }
    public void setUser(User user) throws SQLException {
        String query = "INSERT INTO public.user (name,surname,patronymic,status,comment) VALUES (?,?,?,?,?)";
        PreparedStatement pst = connect.prepareStatement(query);
        pst.setString(1, user.getName());
        pst.setString(2, user.getSurname());
        pst.setString(3, user.getPatronymic());
        pst.setString(4, user.getStatus());
        pst.setString(5, user.getComment());
        pst.executeUpdate();
    }
}
>>>>>>> c51345fcdb90265f01df58930fb8ebacc5ff995e
