read -p "Введите имя " NAME
read -p "Введите фамилию " SURNAME
if [[ "$NAME" == "Adam" && "$SURNAME" == "Bond" ]]
then echo "Access Granted"
fi
