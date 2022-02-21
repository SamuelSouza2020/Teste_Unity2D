<?php
include("../score/connect.php");

$sql = "CREATE TABLE yourDatabaseName2.scor_board (
id INT(6) UNSIGNED AUTO_INCREMENT PRIMARY KEY,
player VARCHAR(255) NOT NULL,
score INT NOT NULL,
score_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
)";

if ($connection->query($sql) === TRUE) {
  echo "Table scor_board created successfully";
} else {
  echo "Error creating table: " . $connection->error;
}

$connection->close();
?>