<?php
	include("../score/connect.php");
	

	$query = "select * from scor_board order by score desc, player LIMIT ".$_GET["limit"];
	
	$result = mysqli_query($connection, $query);
	
		
	while ($row = $result->fetch_assoc()) {
		echo $row['player'].",".$row['score'].",".$row['score_date'].";";
		
	}	
	mysqli_close($connection);
	
?>