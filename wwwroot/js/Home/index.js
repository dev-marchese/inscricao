
const { createApp } = Vue;

createApp({
    data() {
        return {
            alunos: dataView || {}
        };
    },
    methods: {
        async addMatricula() {

            const formData = {
                alunoId: this.matricula.aluno.alunoId,
                cursoId: this.matricula.aluno.cursoId
            };

            try {
                const response = await fetch('/Matricula/Create/', {
                    method: 'POST',
                    headers: {
                        'RequestVerificationToken': $('input[name="__RequestVerificationToken"]').val(),
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify(formData)
                });


                if (!response.ok) {
                    alert('erro ao matricular aluno')
                }
                else {
                    const data = await response.json()
                    if (data.status)
                        //window.location.href = `/Matricula/Index/${data.alunoId}/${data.semestre}/${data.cursoId}`
                        window.location.href = `/Home/Index/`
                    else
                        alert('erro ao matricular aluno')
                }

            } catch (error) {

                alert('erro')
            }
        }
    }
}).mount('#app');