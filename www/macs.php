<?php
$servername = "192.168.0.22";
$username = "ses";
$password = "***";
$dbname = "ses";

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
} 

$sql = "SELECT Serialnumber, mvBlueGEMINI, BlfCam_Profinet, BlfCam_TCP FROM macs";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
    echo "<table border=\"1\"><tr><th>Serialnumber</th><th>mvBlueGEMINI</th><th>BlfCam_Profinet</th><th>BlfCam_TCP</th></tr>";
    // output data of each row
    while($row = $result->fetch_assoc()) {
        echo "<tr><td>".$row["Serialnumber"]."</td><td>".$row["mvBlueGEMINI"]."</td><td>".$row["BlfCam_Profinet"]."</td><td>".$row["BlfCam_TCP"]."</td></tr>";
    }
    echo "</table>";
} else {
    echo "0 results";
}
$conn->close();
?>
