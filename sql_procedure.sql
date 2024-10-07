
DELIMITER $$

CREATE PROCEDURE sp_generate_ra_aluno(IN pAlunoId INT, IN pCursoId INT)
BEGIN
    DECLARE pSemestre TINYINT;

    -- Define o semestre baseado na data atual
    SET pSemestre = IF(MONTH(CURRENT_TIMESTAMP) <= 6, 1, 2);

    -- Insere um registro na tabela AlunoMatricula com o RA gerado
    INSERT INTO AlunoMatricula (AlunoId, Semestre, CursoId, RA)
    VALUES (
        pAlunoId, 
        pSemestre, 
        pCursoId,
        CONCAT(
            YEAR(CURRENT_TIMESTAMP), -- Ano atual
            pSemestre,                -- Semestre atual (1 ou 2)
            LPAD(pAlunoId, 6, '0')    -- AlunoId com 6 dígitos, preenchido com zeros à esquerda
        )
    );
    
    select * from AlunoMatricula where alunoId = pAlunoId and cursoId = pCursoId and semestre = pSemestre;
    
END$$

DELIMITER ;
