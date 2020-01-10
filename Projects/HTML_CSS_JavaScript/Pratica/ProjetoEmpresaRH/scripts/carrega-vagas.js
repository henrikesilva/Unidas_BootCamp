const vagas = [
    {
        "id": "1",
        "titulo": "Programador Java Pleno",
        "tipo": "1"
    },
    {
        "id": "2",
        "titulo": "Analista Comercial",
        "tipo": "2"
    },
    {
        "id": "3",
        "titulo": "Instrutor Excel Avançado",
        "tipo": "1"
    },
    {
        "id": "4",
        "titulo": "Gerente de Projetos para .Net",
        "tipo": "2"
    },
    {
        "id": "5",
        "titulo": "Consultor de Desenvolvimento Ágil",
        "tipo": "2"
    },
    {
        "id": "6",
        "titulo": "Programador VB.Net",
        "tipo": "1"
    },
]

const limpar = function(){
    const selectVagas = $('#vaga')

    selectVagas.empty()

    const def = document.createElement('option')
    def.textContent = 'Selecione a vaga desejava'
    def.setAttribute('value', -1)
    selectVagas.append(def)
}

$('input[name=tipo]').click(function(){
    const selectVagas = $('#vaga')
    limpar()
    
    for(let i = 0; i < vagas.length; i++ ){
        const item = vagas[i]
        if(item.tipo == this.value){
            const option = document.createElement('option')
            option.textContent = item.titulo
            option.setAttribute('value', item.id)
        
            selectVagas.append(option)
        }
    }
})

