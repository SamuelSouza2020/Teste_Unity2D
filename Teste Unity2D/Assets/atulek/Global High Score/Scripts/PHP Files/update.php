<?php

include("connect.php");
 

$player = $_POST["player"];
$score = $_POST["score"];
 

$add = mysqli_query($connection, "UPDATE scor_board SET score = '$score'  WHERE player = '$player' ");
 
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