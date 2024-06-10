echo "1 - просмотр пользователей"
echo "2 - создание пользователя"
echo "3 - удалить пользователя"

read -p "Введите Команду " COMMAND

case "$COMMAND" in 
    "1") cat /etc/passwd;;
    "2") read -p "Введите Имя пользователя " USER && sudo useradd "$USER";;
    "3") read -p "Введите Имя пользователя " USER && sudo userdel "$USER";
esac
