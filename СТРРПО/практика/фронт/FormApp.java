<<<<<<< HEAD
import javax.swing.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.*;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;
import java.nio.charset.StandardCharsets;
import java.text.MessageFormat;
import java.util.Objects;

public class FormApp {
    private JPanel panel1;
    private JTextField Name;
    private JTextField Surname;
    private JTextField Patronymic;
    private JComboBox comboBox1;
    private JTextArea textArea1;
    private JButton Button;
    private JLabel LabelStatus;

    public String checkValue(String value){
        if(!Objects.equals(value, "")){
            return value;
        }
        return null;
    }

    public FormApp() {
        Button.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                StringBuilder body = new StringBuilder();
                body.append(MessageFormat.format("name:{0};", checkValue(Name.getText())));
                body.append(MessageFormat.format("surname:{0};", checkValue(Surname.getText())));
                body.append(MessageFormat.format("patronymic:{0};", checkValue(Patronymic.getText())));
                body.append(MessageFormat.format("status:{0};", checkValue(Objects.requireNonNull(comboBox1.getSelectedItem()).toString())));
                body.append(MessageFormat.format("comment:{0};", checkValue(textArea1.getText())));
                System.out.println(body);
                HttpURLConnection connection = null;
                try {
                    // todo add url на back-end
                    URL url = new URL("http://localhost:8000/api/user");
                    connection = (HttpURLConnection) url.openConnection();
                    connection.setDoOutput(true);
                    connection.setRequestMethod("POST");
                    OutputStream os = connection.getOutputStream();
                    OutputStreamWriter osw = new OutputStreamWriter(os, StandardCharsets.UTF_8);
                    osw.write(body.toString());
                    osw.flush();
                    osw.close();
                    os.close();  //don't forget to close the OutputStream
                    String result;
                    BufferedInputStream bis = new BufferedInputStream(connection.getInputStream());
                    ByteArrayOutputStream buf = new ByteArrayOutputStream();
                    int result2 = bis.read();
                    while(result2 != -1) {
                        buf.write((byte) result2);
                        result2 = bis.read();
                    }
                    result = buf.toString();
                    LabelStatus.setText(result);
                } catch (IOException ex) {
                    throw new RuntimeException(ex);
                } finally {
                    assert connection != null;
                    connection.disconnect();
                }
            }
        });
    }

    public static void main(String[] args) {

        JFrame frame = new JFrame("App");
        JFrame.setDefaultLookAndFeelDecorated(true);
        frame.setContentPane(new FormApp().panel1);
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        frame.pack();
        frame.setSize(500, 500);
        frame.setLocationRelativeTo(null);
        frame.setVisible(true);
    }
}
=======
import javax.swing.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.*;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;
import java.nio.charset.StandardCharsets;
import java.text.MessageFormat;
import java.util.Objects;

public class FormApp {
    private JPanel panel1;
    private JTextField Name;
    private JTextField Surname;
    private JTextField Patronymic;
    private JComboBox comboBox1;
    private JTextArea textArea1;
    private JButton Button;
    private JLabel LabelStatus;

    public String checkValue(String value){
        if(!Objects.equals(value, "")){
            return value;
        }
        return null;
    }

    public FormApp() {
        Button.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                StringBuilder body = new StringBuilder();
                body.append(MessageFormat.format("name:{0};", checkValue(Name.getText())));
                body.append(MessageFormat.format("surname:{0};", checkValue(Surname.getText())));
                body.append(MessageFormat.format("patronymic:{0};", checkValue(Patronymic.getText())));
                body.append(MessageFormat.format("status:{0};", checkValue(Objects.requireNonNull(comboBox1.getSelectedItem()).toString())));
                body.append(MessageFormat.format("comment:{0};", checkValue(textArea1.getText())));
                System.out.println(body);
                HttpURLConnection connection = null;
                try {
                    // todo add url на back-end
                    URL url = new URL("http://localhost:8000/api/user");
                    connection = (HttpURLConnection) url.openConnection();
                    connection.setDoOutput(true);
                    connection.setRequestMethod("POST");
                    OutputStream os = connection.getOutputStream();
                    OutputStreamWriter osw = new OutputStreamWriter(os, StandardCharsets.UTF_8);
                    osw.write(body.toString());
                    osw.flush();
                    osw.close();
                    os.close();  //don't forget to close the OutputStream
                    String result;
                    BufferedInputStream bis = new BufferedInputStream(connection.getInputStream());
                    ByteArrayOutputStream buf = new ByteArrayOutputStream();
                    int result2 = bis.read();
                    while(result2 != -1) {
                        buf.write((byte) result2);
                        result2 = bis.read();
                    }
                    result = buf.toString();
                    LabelStatus.setText(result);
                } catch (IOException ex) {
                    throw new RuntimeException(ex);
                } finally {
                    assert connection != null;
                    connection.disconnect();
                }
            }
        });
    }

    public static void main(String[] args) {

        JFrame frame = new JFrame("App");
        JFrame.setDefaultLookAndFeelDecorated(true);
        frame.setContentPane(new FormApp().panel1);
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        frame.pack();
        frame.setSize(500, 500);
        frame.setLocationRelativeTo(null);
        frame.setVisible(true);
    }
}
>>>>>>> c51345fcdb90265f01df58930fb8ebacc5ff995e
