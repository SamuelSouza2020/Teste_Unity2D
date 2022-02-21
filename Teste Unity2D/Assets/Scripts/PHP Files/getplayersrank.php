<?php
	include("../score/connect.php");
	

	$query = "SELECT (count(*) +1) as rank FROM scor_board WHERE score > (SELECT score FROM scor_board WHERE player like '".$_GET["player"]."' order by score desc) order by score desc ";

	$result = mysqli_query($connection, $query);

		
	while ($row = $result->fetch_assoc()) {
		echo $row['rank'];
		
	}	
	mysqli_close($connection);
	
?>