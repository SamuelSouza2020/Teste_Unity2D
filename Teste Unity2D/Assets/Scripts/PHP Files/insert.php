<?php

include("../scripts2/connect.php");
 

$player = $_POST["player"];
$score = $_POST["score"];
 

$add = mysqli_query($connection, "INSERT INTO scor_board(player,score) VALUES('$player','$score')");
 
if ($add)
{
    echo "Success";
}
else
{
    echo "Error";
}
 mysqli_close($connection);
?>