for VAR in $(cut -f1 -d: /etc/passwd)
do
echo "User: $VAR"
done
