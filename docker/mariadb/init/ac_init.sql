CREATE USER 'ac-debezium'@'%' IDENTIFIED BY '9XxqqlI4n8VcxabJcdLk';
GRANT SELECT, RELOAD, SHOW DATABASES, REPLICATION SLAVE, REPLICATION CLIENT ON *.* TO 'ac-debezium'@'%' IDENTIFIED BY '9XxqqlI4n8VcxabJcdLk';
FLUSH PRIVILEGES;
