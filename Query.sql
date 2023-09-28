CREATE TABLE Teacher (
	Name VARCHAR(255),
	Surname VARCHAR(255),
	Gender VARCHAR(255),
	Subject VARCHAR(255)
);

CREATE TABLE Pupil (
	Name VARCHAR(255),
	Surname VARCHAR(255),
	Gender VARCHAR(255),
	Class VARCHAR(255)
);

SELECT * FROM Teacher WHERE StudentName = "Giorgi";