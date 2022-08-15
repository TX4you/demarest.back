

-- Copiando estrutura do banco de dados para demarest
CREATE DATABASE IF NOT EXISTS `demarest` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `demarest`;

-- Copiando estrutura para tabela demarest.Alunos
CREATE TABLE IF NOT EXISTS `Alunos` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Nome` varchar(50) DEFAULT NULL,
  `SobreNome` varchar(50) DEFAULT NULL,
  `Cpf` varchar(15) DEFAULT NULL,
  `Sexo` varchar(15) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- Copiando dados para a tabela demarest.Alunos: ~0 rows (aproximadamente)
INSERT INTO `Alunos` (`Id`, `Nome`, `SobreNome`, `Cpf`, `Sexo`) VALUES
	(1, 'Erivaldo', 'Oliveira', '222.222.222-22', 'Masculino'),
	(2, 'Mario', 'Henrique', '333.333.333-33', 'Masculino'),
	(3, 'Ana', 'Beatriz', '444.444.444-44', 'Feminino');

-- Copiando estrutura para tabela demarest.AlunosCursos
CREATE TABLE IF NOT EXISTS `AlunosCursos` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `AlunosId` varchar(10) NOT NULL DEFAULT '0',
  `CursosId` varchar(10) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

-- Copiando dados para a tabela demarest.AlunosCursos: ~0 rows (aproximadamente)
INSERT INTO `AlunosCursos` (`Id`, `AlunosId`, `CursosId`) VALUES
	(1, '1', '3'),
	(2, '3', '2'),
	(3, '2', '4'),
	(4, '2', '2');

-- Copiando estrutura para tabela demarest.AlunosFaltas
CREATE TABLE IF NOT EXISTS `AlunosFaltas` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `AlunosId` int(11) NOT NULL DEFAULT 0,
  `CursosId` int(11) NOT NULL DEFAULT 0,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- Copiando dados para a tabela demarest.AlunosFaltas: ~0 rows (aproximadamente)
INSERT INTO `AlunosFaltas` (`Id`, `AlunosId`, `CursosId`) VALUES
	(1, 2, 4),
	(2, 2, 4),
	(3, 2, 4);

-- Copiando estrutura para tabela demarest.Criterios
CREATE TABLE IF NOT EXISTS `Criterios` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Descricao` varchar(50) NOT NULL DEFAULT '0',
  `ValorMinimo` varchar(10) NOT NULL DEFAULT '0',
  `ValorMaximo` varchar(10) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- Copiando dados para a tabela demarest.Criterios: ~3 rows (aproximadamente)
INSERT INTO `Criterios` (`Id`, `Descricao`, `ValorMinimo`, `ValorMaximo`) VALUES
	(1, 'Aprovado', '7.5', '10'),
	(2, 'Conselho', '6', '7.4'),
	(3, 'Reprovado', '0', '5.9');

-- Copiando estrutura para tabela demarest.Cursos
CREATE TABLE IF NOT EXISTS `Cursos` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Descricao` varchar(50) NOT NULL DEFAULT '0',
  `Exclusivo` varchar(10) NOT NULL DEFAULT 'b''0''',
  `Avaliacoes` varchar(10) NOT NULL DEFAULT '0',
  `FrequenciaMinima` varchar(10) DEFAULT NULL,
  `QuantidadeAulas` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;

-- Copiando dados para a tabela demarest.Cursos: ~3 rows (aproximadamente)
INSERT INTO `Cursos` (`Id`, `Descricao`, `Exclusivo`, `Avaliacoes`, `FrequenciaMinima`, `QuantidadeAulas`) VALUES
	(2, 'Inglês', 'Não', '2', '75', '10'),
	(3, 'Alemão', 'Sim', '2', '75', '20'),
	(4, 'Espanhol', 'Não', '2', '75', '10'),
	(8, 'Francês', 'Não', '2', '75', '10');

-- Copiando estrutura para tabela demarest.CursosAvaliacoes
CREATE TABLE IF NOT EXISTS `CursosAvaliacoes` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CursosId` varchar(10) NOT NULL DEFAULT '0',
  `AlunosId` varchar(10) NOT NULL DEFAULT '0',
  `Nota` varchar(10) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- Copiando dados para a tabela demarest.CursosAvaliacoes: ~0 rows (aproximadamente)
INSERT INTO `CursosAvaliacoes` (`Id`, `CursosId`, `AlunosId`, `Nota`) VALUES
	(1, '3', '1', '3,5'),
	(2, '3', '1', '8'),
	(3, '2', '3', '8.5');

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
