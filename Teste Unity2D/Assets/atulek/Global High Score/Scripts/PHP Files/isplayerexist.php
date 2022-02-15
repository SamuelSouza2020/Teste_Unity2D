<?php
	include("connect.php");
	

	$query = "select * from scor_board WHERE player = '".$_GET["player"]."'";
	
	$result = mysqli_query($connection, $query);
	
		
	while ($row = $result->fetch_assoc()) {
		echo $row['player'];		
	}	
	mysqli_close($connection);
	
?>