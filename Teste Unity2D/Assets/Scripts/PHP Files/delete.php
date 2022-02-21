<?php
include("connect.php");
 
mysqli_query($connection, "DELETE FROM scor_board");
mysqli_close($connection);
?>